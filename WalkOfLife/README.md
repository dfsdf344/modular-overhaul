<table align="center"><tr><td align="center" width="9999">

<!-- LOGO, TITLE, DESCRIPTION -->
![](https://stardewcommunitywiki.com/mediawiki/images/8/82/Farming_Skill_Icon.png)
![](https://stardewcommunitywiki.com/mediawiki/images/2/2f/Mining_Skill_Icon.png)
![](https://stardewcommunitywiki.com/mediawiki/images/f/f1/Foraging_Skill_Icon.png)
![](https://stardewcommunitywiki.com/mediawiki/images/e/e7/Fishing_Skill_Icon.png)
![](https://stardewcommunitywiki.com/mediawiki/images/c/cf/Combat_Skill_Icon.png)

# Walk Of Life

**A Professions Overhaul**

<br/>

<!-- TABLE OF CONTENTS -->
<details open="open" align="left">
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#features">Features</a></li>
    <li>
      <a href="#professions">Professions</a>
      <ul>
        <li><a href="#farming">Farming</a></li>
        <li><a href="#foraging">Foraging</a></li>
        <li><a href="#mining">Mining</a></li>
        <li><a href="#fishing">Fishing</a></li>
        <li><a href="#combat">Combat</a></li>
      </ul>
    </li>
    <li><a href="#compatibility">Compatbility</a></li>
    <li><a href="#recommended-mods">Recommended Mods</a></li>
    <li><a href="#installation">Installation</a></li>
    <li><a href="#special-thanks">Special Thanks</a></li>
    <li><a href="#license">License</a></li>
  </ol>
</details>

</td></tr></table>


Ever wondered why there aren't any profession overhaul mods on the Nexus? Me too.


## Features

- Rebalanced and reworked [almost] every profession to be an equally unique and attractive choice.
- Each profession targets a specific style of gameplay, some which were not viable in vanilla (i.e. ranching).
- No more ~~boring~~ uninspiring flat value bonuses.
- Bomberman mining; Assassin, Sniper and Slime-army combat.
- Scaling end-game objectives.
- Level 5 professions provide simple early-game buffs that benefit most styles of general gameplay.
- Level 10 professions are more specialized and engaging, providing two bonuses which change the way you play.
- Professions are more consistent across the board, with several analogous perks and synergies.
- Lightweight. This mod is built with a dynamic event handling system to avoid overhead.
- New icons for most professions, courtesy of [IllogicalMoodSwing](https://forums.nexusmods.com/index.php?/user/38784845-illogicalmoodswing/) (please make sure to [endorse their original](https://www.nexusmods.com/stardewvalley/mods/4163) mod).


## Professions

### ![](https://i.imgur.com/p9QdB6L.png) Farming

- **Lv5 - Harvester** - 10% chance for extra yield from harvested crops.
    - This yields an equivalent 10% monetary bonus to vanilla, but also brings additional benefit to Artisans.
- **Lv10 - Agriculturist** - Crops grow 10% faster. Grow best-quality crops organically without fertilizer.
    - Allows harvesting iridium-quality crops without any fertilizer. The chance is unchanged from vanilla, and is equal to half the chance of gold quality. Fertilizers will still massively increase that chance.
- **Lv10 - Artisan** - All artisan machines work 10% faster. Machine output quality is at least as good as input ingredient quality.
    - Essentially implements [Quality Artisan Products](https://www.moddrop.com/stardew-valley/mods/707502-quality-artisan-products) (QAP), but exclusively for Artisans. Also adds 5% chance to promote the output quality by one level. In multiplayer, **the bonus production speed applies only to machines crafted by the player with this profession, and only when that player uses the machine**.
- **Lv5 - Rancher** - Befriend animals quicker.
    - Gain double mood and friendship points from petting. Newborn animals are born with some starting friendship between 150 and 250 (out of 1000 maximum), chosen at random.
- **Lv10 - Breeder** - Animals incubate faster and breed more frequently. Increase value of animals at high friendship.
    - Makes mammals three times as likely to give birth and oviparous (egg-laying) animals incubate twice as fast. At max friendship animals are worth 2.5x their base price, instead of vanilla 1.3x.
- **Lv10 - Producer** - Happy animals produce twice as frequently. Produce worth 5% more for every full barn or coop.
    - Note that happiness (mood) is **not** the same as friendship. Also note this will **not** allow certain animals (i.e. cows and chickens) to produce more than once per day. Bonus produce value also applies to artisan goods derived from animal products (i.e. cheeses, mayos and cloth) and to honey (bees are animals). Only deluxe buildings can be considered full. **Note that honey is also considered an animal product.** There is no limit to the scaling. In multiplayer, **the bonus applies only to barns and coops owned by the player with this profession, and only when that player sells the produce**.

### ![](https://i.imgur.com/jf88nPt.png) Foraging

- **Lv5 - Forager** - 20% chance for double yield of foraged items.
    - _Unchanged effect from vanilla. Only the name is changed._
- **Lv10 - Ecologist** - Wild berries restore 50% more health and energy. Progressively identify forage of higher quality.
    - All foraged items will have the same deterministic quality. This immediate gives inventory convenience. However the quality will start off at silver, and progress to iridium when enough items have been foraged. Applies to Mushroom Boxes, but only if the cave owner (i.e. the host player) has the profession.
- **Lv10 - Scavenger** - Location of forageable items revealed. Occasionally detect buried treasure.
    - On switching maps while outside you will occasionally detect hidden buried treasure. Find it and dig it up (with a hoe) within the time limit to obtain your reward. The larger your win streak the better your odds of obtaining rare items. _Bonus: hold LeftShift (or LeftShoulder on gamepad) to reveal all forageables on-screen._
- **Lv5 - Lumberjack** - Felled trees yield 25% more wood.
    - _Unchanged effect from vanilla. Only the name is changed._
- **Lv10 - Arborist** - All trees grow faster and can drop hardwood.
    - Bonus tree growth works as a global buff; i.e. in multiplayer, all trees will be affected as long as any player in the session has this profession, and the effect will stack for all additional online players that share this profession. _The hardwood bonus is unchanged from vanilla._
- **Lv10 - Tapper** - Tappers are cheaper to craft. Tapped trees give syrup 25% faster.
    - New recipe: x25 wood and x1 copper bar.

### ![](https://i.imgur.com/TidtIw0.png) Mining 

- **Lv5 - Miner** - +1 ore per ore vein.
    - _Unchanged from vanilla._
- **Lv10 - Spelunker** - Chance to find ladders and shafts increases by 1% every mine level. +1 speed every 10 levels.
    - Bonus ladder chance resets every time you leave the mines. **This includes taking the stairs back to the mine entrance.**
- **Lv10 - Prospector** - Location of ladders and mining nodes revealed. Occasionally detect rocks with valuable minerals.
    - Analogous to Scavenger. Tracks any mining nodes or mineral forages off-screen with a yellow pointer, and any ladders or shafts with a green pointer. On entering a new mine floor you will occasionally detect stones with prospective treasure. Find the stone and break it within the time limit to obtain a reward. The larger your win streak the better your odds of obtaining rare items. _Bonus: hold LeftShift to highlight nodes and ladders on-screen._
- **Lv5 - Blaster** - Bombs are cheaper to craft. Exploded rocks yield twice as much coal.
    - New recipe: x2 ore (copper, iron, gold) and x1 coal.
- **Lv10 - Demolitionist** - Bomb radius +1. Exploded rocks yield 20% more resources.
    - _Bonus: [Get excited!](https://www.youtube.com/watch?v=0nlJuwO0GDs) when hit by an explosion._
- **Lv10 - Gemologist** - Progressively identify gems and minerals of higher quality. Crystalariums work 25% faster.
    - Analogous to Ecologist. All gems and minerals mined from nodes have a fixed quality, starting at silver and increasing once enough minerals have been collected. Minerals collected from Crystalariums and Geode Crushers are counted for this total, **but not those from geodes broken at Clint's**. In multiplayer, **the bonus Crystalarium speed applies only to machines crafted by the player with this profession, and only when used by that player**.

### ![](https://i.imgur.com/XvdVsAn.png) Fishing

- **Lv5 - Fisher** - Live bait reduces the chance to fish junk.
    - Here, "junk" includes algae and seaweed.
- **Lv10 - Angler** - Fish worth 1% more for every unique max-sized fish caught and 5% more for every legendary fish.
    - "Legendary fish" includes the Extended Family Qi challenge varieties, counted only once.
- **Lv10 - Aquarist** - Fish pond max capacity +2. Fishing bar height increases for every fish pond at max capacity.
    - Gain 6 pixels per Fish Pond. Every four ponds equal a permanent cork bobber. In multiplayer, **only counts Fish Ponds owned by the player with this profession**.
- **Lv5 - Trapper** - Crab pots are cheaper to craft. Can trap higher-quality haul.
    - All trapped fish can have quality up to gold. Chance depends on your fishing level (same formula as forage). _Recipe is unchanged from vanilla._
- **Lv10 - Luremaster** - Crab pots no longer produce junk. Use different baits to attract different catch.
    - Each type bait will attract different catch:
        - **Regular bait:** 10% chance to catch fish up to level 70. Trappable fish are subject to the same location and season limitations as regular fishing.
        - **Wild bait:** 10% chance to catch fish up to level 90 (i.e. anything but legendaries and octopus). 50% chance to double the haul.
        - **Magnet:** repels all fish (as per its description), but attracts metal items such as resources, artifacts, treasure chests, rings and even weapons.
        - **Magic bait:** 25% chance to catch fish above level 70, excluding legendaries. Removes all location and seasonal restrictions for catching fish. Makes all catch iridium-quality. _This is the only way to obtain iridium-quality fish from Crab Pots._
- **Lv10 - Conservationist** - Crab pots without bait will trap junk. Clean the Valley's waters to merit village favor and tax deductions.
    - Every 10 (configurable) junk items collected from Crab Pots increases friendship with all villagers by 1. Every 100 (configurable) junk items collected will earn you a 1% tax deduction the following season (max 25%, also configurable), increasing the value of all shipped goods. You will receive a formal mail from the Ferngill Revenue Service each season informing your currrent tax bracket.

### ![](https://i.imgur.com/fUnZSTj.png) Combat

The combat tree has received a much more extensive overhaul. Each level 10 profession introduces, in addition to a fixed primary effect, a secondary stackable attribute and a [Super Mode](https://tvtropes.org/pmwiki/pmwiki.php/Main/SuperMode) that may be activated by a hot key _only once the maximum number of stacks has been collected_. Activating Super Mode will consume **all** stacks, reseting the secondary attribute, but granting a strong combat buff for a short time. A new bar added to the UI next to the health bar displays the current stack count. **If a player has multiple combat professions (e.g. if using a mod like All Professions or Skill Prestige), only the first one will register a secondary attribute and a Super Mode; any subsequent professions will only apply their base effect.**

- **Lv5 - Fighter** - Damage +10%. +15 HP.
    - _Unchanged from vanilla._
- **Lv10 - Brute** - Damage +15%. +25 HP. Build fury in combat, further increasing damage.
    - Damage bonus caps at +40%. If wielding a club the cap is 60%. Also gain up to 50% cooldown reduction to club smash attack.
    - **Undying Rage:** Doubles all damage bonuses. Immune to passing out.
        - Doubles damage bonus from all sources, including profession, rings and enchantments.
- **Lv10 - Bushwhacker** - +10% crit. chance. Crit. strikes are deadlier at low HP and build chance to poach an item on hit.
    - Crit. Power increases up to x2 at 10% HP. Monsters can only be poached once. Also gain up to 50% cooldown reduction to dagger quick-stab attack.
    - **Ambuscade:** Become invisible and untargetable. Back stabs cause lethal damage.
		- Missing a back stab will cancel the status and reveal your position once again.
- **Lv 5 - Rascal** - Slingshots deal up to 50% more damage from afar. 60% chance to recover spent ammo.
- **Lv10 - Desperado** - 35% ammo damage modifier. Ranged hits build chance to perform a double shot.
    - Better ammo will gain a much higher damage bonus. Also reduce slingshot pull-back time by up to 50% (requires hold-to-charge mode).
    - **Death Blossom:** Enable auto-reload. Fire in eight directions at once.
- **Lv10 - Slimed Piper** - Slimes damage other enemies. Slime drops improve for every Slime raised on the farm. Increase spawned Slimes in dungeons.
    - Slimes cannot damage flying enemies.
    - Each Slime raised on the farm, either in a hutch or outside, increase the chance for Slimes to drop additional items.
    - Every dungeon floor can spawn up to 11 additional Slimes, based on the Super Mode meter.
    - The Piper will recover 1 HP on contact with Slimes. **This does not negate Slime damage. A Slime Charmer ring is still required.**
    - **Superfluidity:** Cause Slimes to grow up to twice their size. Large enough Slimes break into smaller Slimes when defeated.
        - Low chance to convert Slimes to a special variant. If "Prismatic Jelly" special order is active, low chance to convert Slimes to prismatic variant.
        - Giant Slimes can hit flying enemies.
        - Also increases healed amount based on the Slime's actual damage.

## Configs

While the vast majority of professions bonuses are non-configurable, some of the more radical changes have been given configuration options to give the user some degree of control. As such the mod provides the following config options, which can be modified either in-game via Generic Mod Config Menu or by manually editing the configs.json file:

- **Modkey** - The Prospector and Scavenger professions use this key to reveal the locations of key objects currently on the screen. If playing on a large screen with wide field of view, this can help locate forageables of mine nodes in large or busy maps. The default key is LeftShift for keyboards and LeftShoulder for controllers.
- **SuperModeKey** - This is the key that activates Super Mode for level 10 combat professions. By default this is the same key as Modkey, but can also be set to a different key.
- **HoldKeyToActivateSuperMode** - If set to true, then Super Mode will be activated after holding the above key for a short amount of time. If set to false, then Super Mode will activate immediately upon pressing the key. This is settings is useful if SuperModeKey is set to a key already bound to a different on-press action, such as if keeping the default keybind settings for Modkey and SuperModeKey which will allowing tracking on-screen items without activating Super Mode. Default value is true. 
- **SuperModeActivationDelay** - If HoldKeyToActivateSuperMode is set to true, this represents the number of seconds between pressing SuperModeKey and activating Super Mode. Set to a higher value if you use Prospector profession and find yourself accidentally wasting your Super Mode in the Mines.
- **SuperModeDrainFactor** - Determines how quickly the Super Mode resource bar drains during Super Mode. This number represents the amount of game update ticks between each tick of the Super Mode resource bar. The default value is 3, which means that 1 point is deduced every 3 / 60 = 0.05 seconds, giving a total Super Mode duration of 0.05 * 500 = 25 seconds. 
- **ForagesNeededForBestQuality** - Determines the number of items foraged from the ground, bushes or mushroom boxes, required to reach permanent iridium-quality forage as an Ecologist. Default is 500.
- **MineralsNeededForBestQuality** - As above. Determines the number of minerals (gems or foraged minerals) mined or collected from geode crushers or crystalariums, required to reach permanent iridium-quality minerals as a Gemologist. Default it 500.
- **ChanceToStartTreasureHunt** - The percent chance of triggering a treasure hunt when entering a new map as Prospector or Scavenger. Note that this only affects that chance the game will try to start a treasure hunt, and the actual chance is slightly lower as the game might fail to choose a valid treasure tile. Increase this value if you don't see enough treasure hunts, or decrease it if you find treasure hunts cumbersome and don't want to lose your streak. Default is 0.2 (20%).
- **TreasureDetectionDistance** - Represents the minimum number of adjacent tiles between the player and the treasure tile before the treasure tile will be revealed by a floating arrow. Increase this value is you find treasure hunts too difficult. Default is 3.
- **TrashNeededPerTaxLevel** - Represents the number of trash items the Conservationist must collect in order to gain a 1% tax deduction the following season. Use this value to balance your game if you use or don't use Automate. Default is 100.
- **TrashNeededPerFriendshipPoint** - Represents the number of trash items the Conservationist must collect in order to gain 1 point of friendship towards all villagers. Default is 100.
- **TaxDeductionCeiling** - Represents the maximum allowed tax deduction by the Ferngill Revenue Service. Set this to a sensible value to avoid breaking your game. Default is 0.25 (25% bonus value on every item).
- **EnableILCodeExport** - If during launch you see red text in SMAPI that looks like this: "Failed to patch _____", then enabling this setting will create a '.cil' file in the mod folder for every patching error. This is mostly to help myself fix patching bugs, but submitting this along with your SMAPI log in a bug report can be very helpful.

## Console Commands

The mod provides the following console commands, which you can enter in the SMAPI console for testing, checking or cheating:

- **player_checkprofessions** - List the player's current professions.
- **player_addprofessions** - Add the specified professions to the local player.
- **player_resetprofessions** - Reset all skills and professions for the local player.
- **setultmeter** - Set the super mode meter to the desired value.
- **readyult** - Max-out the super mode meter.
- **registersupermode** - Change the currently registered Super Mode profession.
- **maxanimalfriendship** - Max-out the friendship of all owned animals, which affects their sale value as Breeder.
- **maxanimalmood** - Max-out the mood of all owned animals, which affects production frequency as Producer.
- **checkfishingprogress** - Check your fishing progress and bonus fish value as Angler.
- **checkdata** - Check current value of all mod data fields (ItemsForaged, MineralsCollected, ProspectorStreak, ScavengerStreak, WaterTrashCollectedThisSeason, ActiveTaxBonusPercent).
- **setitemsforaged** - Set a new value for ItemsForaged field, which determines the quality of items foraged as Ecologist.
- **setmineralscollected** - Set a new value for MineralsCollected field, which determines the quality of minerals mines as Gemologist.
- **setprospectorstreak** - Set a new value for ProspectorStreak field.
- **setscavengerstreak** - Set a new value for ScavengerStreak field.
- **settrashcollected** - Set a new value for WaterTrashCollectedThisSeason field, which determines your tax bracket the following season as Conservationist.
- **checkevents** - List currently subscribed mod events (for debugging).

## Compatbility

The mod is compatible with the following popular mods:

- [Automate](https://www.nexusmods.com/stardewvalley/mods/1063) (for craftable machines, the machine's owner's professions will apply; for terrain features, i.e. berry bushes, only the session host's professions will apply)
- [CJB Cheats Menu] (https://www.nexusmods.com/stardewvalley/mods/4) (you will have to manually change that mod's localization file to fix incorrect profession names, if you care about that)
- [Multi Yield Crops](https://www.nexusmods.com/stardewvalley/mods/6069)
- Custom SpaceCore skills (e.g. [Luck](https://www.nexusmods.com/stardewvalley/mods/521), [Magic](https://www.nexusmods.com/stardewvalley/mods/2007)) or [Love Of Cooking](https://www.nexusmods.com/stardewvalley/mods/6830))
- [Capstone Professions](https://www.nexusmods.com/stardewvalley/mods/7636)
- [All Professions](https://www.nexusmods.com/stardewvalley/mods/174) (profession perks will not be applied immediately, but the following morning)
- [Skill Prestige](https://www.nexusmods.com/stardewvalley/mods/569#) (same as above; the Prestige menu also won't reflect modded profession names or descriptions)

The mod is not compatible with the following mods:

- Any mods that change vanilla skills.
- [Better Crab Pots](https://www.nexusmods.com/stardewvalley/mods/3159), [Crab Pot Loot Has Quality And Bait Effects](https://www.nexusmods.com/stardewvalley/mods/7767) or any mod that affects Crab Pot behavior.
- [Quality Artisan Products](https://www.moddrop.com/stardew-valley/mods/707502-quality-artisan-products) and [Quality Artisan Products for Artisan Valley](https://www.moddrop.com/stardew-valley/mods/726947-quality-artisan-products-for-artisan-valley) (won't break anything, but makes Artisan profession redundant; all features are already included). 
- [Forage Fantasy](https://www.nexusmods.com/stardewvalley/mods/7554) (mushroom box quality is already included; other features may cause bad interactions with foraging professions).

## Recommended Mods

- [Advanced Casks](https://www.nexusmods.com/stardewvalley/mods/8413) (if you miss Oenologist profession perk).
- [Artisan Valley](https://www.nexusmods.com/stardewvalley/mods/1926) (add variety to Artisan products and Producer).
- [Slime Produce](https://www.nexusmods.com/stardewvalley/mods/7634) (make Slime ranching more interesting and profitable).
- [Ostrich Mayo and Golden Mayo](https://www.nexusmods.com/stardewvalley/mods/7660) (better consistency between Ostrich and Golden eggs for Artisan profession).﻿

## Installation

- You can install this mod on an existing save; all perks will be retroactively applied upon loading a saved game.
- To install simply drop the extracted folder onto your mods folder.
- To update make sure to delete the old version first and only then install the new version.
- There are no dependencies outside of SMAPI.

## Special Thanks

- [Bpendragon](https://www.nexusmods.com/stardewvalley/users/20668164) for [Forage Pointers](https://www.nexusmods.com/stardewvalley/mods/7781).
- [IllogicalMoodSwing](https://forums.nexusmods.com/index.php?/user/38784845-illogicalmoodswing/) for [Profession Icons Redone](https://www.nexusmods.com/stardewvalley/mods/4163).
- Himetarts for the title logo.
- [Pathoschild](https://www.nexusmods.com/stardewvalley/users/1552317) for SMAPI support.
- **ConcernedApe** for Stardew Valley.
- [JetBrains](https://jb.gg/OpenSource) for providing a free license to their tools.

<table>
  <tr>
    <td><img width="64" src="https://smapi.io/Content/images/pufferchick.png" alt="Pufferchick"></td>
    <td><img width="80" src="https://resources.jetbrains.com/storage/products/company/brand/logos/jb_beam.svg" alt="JetBrains logo."></td>
  </tr>
</table>



## License

Distributed under the MIT License. See [LICENSE](../LICENSE) for more information.