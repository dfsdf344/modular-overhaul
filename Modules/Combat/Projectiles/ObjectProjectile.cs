﻿namespace DaLion.Overhaul.Modules.Combat.Projectiles;

#region using directives

using DaLion.Overhaul.Modules.Combat.Enchantments;
using DaLion.Overhaul.Modules.Combat.Extensions;
using DaLion.Overhaul.Modules.Combat.VirtualProperties;
using DaLion.Overhaul.Modules.Professions.Extensions;
using DaLion.Overhaul.Modules.Professions.Ultimates;
using DaLion.Overhaul.Modules.Professions.VirtualProperties;
using DaLion.Shared.Constants;
using DaLion.Shared.Enums;
using DaLion.Shared.Extensions.Stardew;
using DaLion.Shared.Extensions.Xna;
using Microsoft.Xna.Framework;
using Netcode;
using StardewValley.Monsters;
using StardewValley.Objects;
using StardewValley.Projectiles;
using StardewValley.Tools;

#endregion using directives

/// <summary>An <see cref="SObject"/> fired by a <see cref="Slingshot"/>.</summary>
internal sealed class ObjectProjectile : BasicProjectile
{
    private int _pierceCount;

    /// <summary>Initializes a new instance of the <see cref="ObjectProjectile"/> class.</summary>
    /// <remarks>Required for multiplayer syncing.</remarks>
    public ObjectProjectile()
        : base()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ObjectProjectile"/> class.</summary>
    /// <param name="ammo">The <see cref="SObject"/> that was fired.</param>
    /// <param name="index">The index of the fired ammo (this may be different from the index of the <see cref="SObject"/>).</param>
    /// <param name="source">The <see cref="Slingshot"/> which fired this projectile.</param>
    /// <param name="firer">The <see cref="Farmer"/> who fired this projectile.</param>
    /// <param name="damage">The un-mitigated damage this projectile will cause.</param>
    /// <param name="knockback">The knockback this projectile will cause.</param>
    /// <param name="overcharge">The amount of overcharge with which the projectile was fired.</param>
    /// <param name="startingPosition">The projectile's starting position.</param>
    /// <param name="xVelocity">The projectile's starting velocity in the horizontal direction.</param>
    /// <param name="yVelocity">The projectile's starting velocity in the vertical direction.</param>
    /// <param name="rotationVelocity">The projectile's starting rotational velocity.</param>
    public ObjectProjectile(
        Item ammo,
        int index,
        Slingshot source,
        Farmer firer,
        float damage,
        float knockback,
        float overcharge,
        Vector2 startingPosition,
        float xVelocity,
        float yVelocity,
        float rotationVelocity)
        : base(
            (int)damage,
            index,
            0,
            0,
            rotationVelocity,
            xVelocity,
            yVelocity,
            startingPosition,
            ammo.ParentSheetIndex == ObjectIds.ExplosiveAmmo ? "explosion" : "hammer",
            string.Empty,
            ammo.ParentSheetIndex == ObjectIds.ExplosiveAmmo,
            true,
            firer.currentLocation,
            firer,
            true,
            ammo.ParentSheetIndex == ObjectIds.ExplosiveAmmo ? explodeOnImpact : null)
    {
        this.Ammo = ammo;
        this.Source = source;
        this.Firer = firer;
        this.Overcharge = overcharge;
        this.Damage = (int)(this.damageToFarmer.Value * source.Get_EffectiveDamageModifier() *
                            (1f + firer.attackIncreaseModifier) * overcharge);
        this.Knockback = (knockback + source.Get_EffectiveKnockback()) * (1f + firer.knockbackModifier) *
                         overcharge;

        this.CritChance = 0f;
        this.CritPower = 0;
        if (CombatModule.Config.EnableRangedCriticalHits)
        {
            this.CritChance = source.Get_EffectiveCritChance() * (1f + firer.critChanceModifier);
            this.CritPower = (1f + source.Get_EffectiveCritPower()) * (1f + firer.critPowerModifier);
        }

        if (this.IsSquishy)
        {
            Reflector
                .GetUnboundFieldGetter<BasicProjectile, NetString>(this, "collisionSound")
                .Invoke(this).Value = "slimedead";
        }

        if (firer.professions.Contains(Farmer.scout) && !this.IsSquishy && ProfessionsModule.Config.ModKey.IsDown() &&
            !source.CanAutoFire())
        {
            this.Damage = (int)(this.Damage * 0.8f);
            this.Knockback *= 0.8f;
            this.Overcharge *= 0.8f;
            this.bouncesLeft.Value++;
        }

        this.ignoreTravelGracePeriod.Value = CombatModule.Config.RemoveSlingshotGracePeriod;

        if (this.Overcharge > 1f)
        {
            this.tailLength.Value = (int)((this.Overcharge - 1f) * 5f);
        }
    }

    public Item? Ammo { get; }

    public Farmer? Firer { get; }

    public Slingshot? Source { get; }

    public int Damage { get; private set; }

    public float Overcharge { get; private set; }

    public float Knockback { get; private set; }

    public float CritChance { get; }

    public float CritPower { get; }

    public bool DidBounce { get; private set; }

    public bool DidPierce { get; private set; }

    public int Index => this.currentTileSheetIndex.Value;

    /// <summary>Gets a value indicating whether the projectile should pierce and bounce or make squishy noises upon collision.</summary>
    public bool IsSquishy => this.Ammo?.Category is (int)ObjectCategory.Eggs or (int)ObjectCategory.Fruits or (int)ObjectCategory.Vegetables ||
                             this.Ammo?.ParentSheetIndex == ObjectIds.Slime;

    /// <inheritdoc />
    public override void behaviorOnCollisionWithMineWall(int tileX, int tileY)
    {
        this.DidPierce = false;
        base.behaviorOnCollisionWithMineWall(tileX, tileY);
    }

    /// <inheritdoc />
    public override void behaviorOnCollisionWithMonster(NPC n, GameLocation location)
    {
        if (this.Ammo is null || this.Firer is null || this.Source is null || n is not Monster { IsMonster: true } monster)
        {
            base.behaviorOnCollisionWithMonster(n, location);
            return;
        }

        if (this.Ammo.ParentSheetIndex == ObjectIds.Slime)
        {
            if (monster.IsSlime())
            {
                if (!this.Firer.professions.Contains(Farmer.acrobat))
                {
                    return;
                }

                // do heal Slime
                var amount = Game1.random.Next(this.Damage - 2, this.Damage + 2);
                monster.Health = Math.Min(monster.Health + amount, monster.MaxHealth);
                location.debris.Add(new Debris(
                    amount,
                    new Vector2(monster.getStandingX() + 8, monster.getStandingY()),
                    Color.Lime,
                    1f,
                    monster));
                //Game1.playSound("healSound");
                Reflector
                    .GetUnboundMethodDelegate<Action<BasicProjectile, GameLocation>>(this, "explosionAnimation")
                    .Invoke(this, location);

                return;
            }

            if (monster.CanBeSlowed() && CombatModule.ShouldEnable && Game1.random.NextDouble() < 2d / 3d)
            {
                // do debuff
                monster.Slow(5123 + (Game1.random.Next(-2, 3) * 456), 1d / 3d);
                monster.startGlowing(Color.LimeGreen, false, 0.05f);
            }
        }

        location.damageMonster(
            monster.GetBoundingBox(),
            this.Damage,
            this.Damage + 1,
            this.Ammo.ParentSheetIndex == ObjectIds.ExplosiveAmmo,
            this.Knockback,
            0,
            this.CritChance,
            this.CritPower,
            true,
            this.Firer);

        if (!ProfessionsModule.ShouldEnable || !this.Firer.professions.Contains(Farmer.desperado))
        {
            Reflector
                .GetUnboundMethodDelegate<Action<BasicProjectile, GameLocation>>(this, "explosionAnimation")
                .Invoke(this, location);
            return;
        }

        // check for piercing
        if (this.Firer.professions.Contains(Farmer.desperado + 100) && !this.IsSquishy &&
            this.Ammo.ParentSheetIndex != ObjectIds.ExplosiveAmmo && this._pierceCount < 2 &&
            Game1.random.NextDouble() < this.Overcharge - 1f)
        {
            this.Damage = (int)(this.Damage * 0.65f);
            this.Knockback *= 0.65f;
            this.Overcharge *= 0.65f;
            this.xVelocity.Value *= 0.65f;
            this.yVelocity.Value *= 0.65f;
            this.DidPierce = true;
            this._pierceCount++;
        }
        else
        {
            Reflector
                .GetUnboundMethodDelegate<Action<BasicProjectile, GameLocation>>(this, "explosionAnimation")
                .Invoke(this, location);
        }

        // check for stun
        //if (this.Firer.professions.Contains(Farmer.scout + 100) && this.DidBounce)
        //{
        //    monster.stunTime = 2000;
        //}

        // increment Desperado ultimate meter
        if (this.Firer.IsLocalPlayer && this.Firer.Get_Ultimate() is DeathBlossom { IsActive: false } blossom &&
            ProfessionsModule.Config.EnableLimitBreaks)
        {
            blossom.ChargeValue += (this.DidBounce || this.DidPierce ? 18 : 12) -
                                   (10 * this.Firer.health / this.Firer.maxHealth);
        }

        if (this.Source?.hasEnchantmentOfType<PreservingEnchantment>() == true || this.IsSquishy ||
            this.Ammo.ParentSheetIndex == ObjectIds.ExplosiveAmmo || !this.Firer.professions.Contains(Farmer.scout))
        {
            return;
        }

        // try to recover
        var chance = this.Ammo.ParentSheetIndex is ObjectIds.Wood or ObjectIds.Coal ? 0.175 : 0.35;
        if (this.Firer.professions.Contains(Farmer.scout + 100))
        {
            chance *= 2d;
        }

        chance -= this._pierceCount * 0.2;
        if (chance < 0d || Game1.random.NextDouble() > chance)
        {
            return;
        }

        location.debris.Add(
            new Debris(
                this.Ammo.ParentSheetIndex,
                new Vector2((int)this.position.X, (int)this.position.Y),
                this.Firer.getStandingPosition()));
    }

    /// <inheritdoc />
    public override void behaviorOnCollisionWithOther(GameLocation location)
    {
        this.DidPierce = false;
        base.behaviorOnCollisionWithOther(location);
        if (this.Ammo is null || this.Firer is null || this.Source is null || !ProfessionsModule.ShouldEnable)
        {
            return;
        }

        if (this.Ammo.ParentSheetIndex == ObjectIds.Slime &&
            this.Firer.Get_Ultimate() is Concerto { IsActive: false } concerto)
        {
            concerto.ChargeValue += Game1.random.Next(5);
            return;
        }

        if (this.Source?.hasEnchantmentOfType<PreservingEnchantment>() == true || this.IsSquishy ||
            this.Ammo.ParentSheetIndex == ObjectIds.ExplosiveAmmo || !this.Firer.professions.Contains(Farmer.scout))
        {
            return;
        }

        // try to recover
        var chance = this.Ammo.ParentSheetIndex is ObjectIds.Wood or ObjectIds.Coal ? 0.175 : 0.35;
        if (this.Firer.professions.Contains(Farmer.scout + 100))
        {
            chance *= 2d;
        }

        chance -= this._pierceCount * 0.2;
        if (chance < 0d || Game1.random.NextDouble() > chance)
        {
            return;
        }

        location.debris.Add(
            new Debris(
                this.Ammo.ParentSheetIndex,
                new Vector2((int)this.position.X, (int)this.position.Y),
                this.Firer.getStandingPosition()));
    }

    /// <inheritdoc />
    public override bool update(GameTime time, GameLocation location)
    {
        if (this.Ammo is null || this.Firer is null || this.Source is null)
        {
            return base.update(time, location);
        }

        var bounces = this.bouncesLeft.Value;
        var didCollide = base.update(time, location);
        if (!didCollide)
        {
            var boundingBox = this.getBoundingBox();
            var tilePosition = new Vector2(boundingBox.Center.X / Game1.tileSize, boundingBox.Center.Y / Game1.tileSize);
            if (location.Objects.TryGetValue(tilePosition, out var @object))
            {
                didCollide = this.BehaviorOnCollisionWithObject(location, @object);
            }
        }

        if (bounces > this.bouncesLeft.Value)
        {
            this.DidBounce = true;
        }

        if (this.Overcharge <= 1f || (this.maxTravelDistance.Value > 0 && this.travelDistance >= this.maxTravelDistance.Value))
        {
            return didCollide;
        }

        // check if already collided
        if (didCollide)
        {
            return !this.DidPierce;
        }

        this.DidPierce = false;

        // get trajectory angle
        var velocity = new Vector2(this.xVelocity.Value, this.yVelocity.Value);
        var angle = velocity.AngleWithHorizontal();
        if (angle > 180)
        {
            angle -= 360;
        }

        // check for extended collision
        var originalHitbox = this.getBoundingBox();
        var newHitbox = new Rectangle(originalHitbox.X, originalHitbox.Y, originalHitbox.Width, originalHitbox.Height);
        var isBulletTravelingVertically = Math.Abs(angle) is >= 45 and <= 135;
        if (isBulletTravelingVertically)
        {
            newHitbox.Inflate((int)(originalHitbox.Width * this.Overcharge), 0);
            if (newHitbox.Width <= originalHitbox.Width)
            {
                return didCollide;
            }
        }
        else
        {
            newHitbox.Inflate(0, (int)(originalHitbox.Height * this.Overcharge));
            if (newHitbox.Height <= originalHitbox.Height)
            {
                return didCollide;
            }
        }

        if (location.doesPositionCollideWithCharacter(newHitbox) is not Monster monster)
        {
            return didCollide;
        }

        // deal damage
        int actualDistance, monsterRadius, actualBulletRadius, extendedBulletRadius;
        if (isBulletTravelingVertically)
        {
            actualDistance = Math.Abs(monster.getStandingX() - originalHitbox.Center.X);
            monsterRadius = monster.GetBoundingBox().Width / 2;
            actualBulletRadius = originalHitbox.Width / 2;
            extendedBulletRadius = newHitbox.Width / 2;
        }
        else
        {
            actualDistance = Math.Abs(monster.getStandingY() - originalHitbox.Center.Y);
            monsterRadius = monster.GetBoundingBox().Height / 2;
            actualBulletRadius = originalHitbox.Height / 2;
            extendedBulletRadius = newHitbox.Height / 2;
        }

        var lerpFactor = (actualDistance - (actualBulletRadius + monsterRadius)) /
                         (extendedBulletRadius - actualBulletRadius);
        var multiplier = MathHelper.Lerp(1f, 0f, lerpFactor);
        var adjustedDamage = (int)(this.Damage * multiplier);
        location.damageMonster(
            monster.GetBoundingBox(),
            adjustedDamage,
            adjustedDamage + 1,
            this.Ammo.ParentSheetIndex == ObjectIds.ExplosiveAmmo,
            this.Knockback,
            0,
            this.CritChance,
            this.CritPower,
            true,
            this.Firer);
        return didCollide;
    }

    internal bool BehaviorOnCollisionWithObject(GameLocation location, SObject @object)
    {
        if (@object is not BreakableContainer container)
        {
            return false; // if the object is not a container, the projectile continues on its way
        }

        var dummyWeapon = new MeleeWeapon { BaseName = string.Empty };
        Reflector.GetUnboundFieldSetter<Tool, Farmer>(dummyWeapon, "lastUser").Invoke(dummyWeapon, this.Firer ?? Game1.player);
        if (!container.performToolAction(dummyWeapon, location))
        {
            return true; // if the container did not break, the projectile is stopped
        }

        location.Objects.Remove(@object.TileLocation);
        return false; // if the container broke, then the projectile lives on
    }
}
