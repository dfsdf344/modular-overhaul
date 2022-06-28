﻿namespace DaLion.Stardew.Tweex.Framework.Patches;

#region using directives

using Common;
using Common.Extensions.Reflection;
using Common.Harmony;
using Extensions;
using HarmonyLib;
using JetBrains.Annotations;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using SObject = StardewValley.Object;

#endregion using directives

[UsedImplicitly]
internal sealed class ObjectCheckForActionPatch : Common.Harmony.HarmonyPatch
{
    /// <summary>Construct an instance.</summary>
    internal ObjectCheckForActionPatch()
    {
        Target = RequireMethod<SObject>(nameof(SObject.checkForAction));
    }

    #region harmony patches

    /// <summary>Detects if an object is ready for harvest.</summary>
    [HarmonyPrefix]
    // ReSharper disable once RedundantAssignment
    private static bool ObjectCheckForActionPrefix(SObject __instance, ref bool __state)
    {
        __state = __instance.heldObject.Value is not null &&
                  __instance.readyForHarvest.Value;
        return true; // run original logic
    }

    /// <summary>Adds foraging experience if a tapper or mushroom box was harvested.</summary>
    [HarmonyPostfix]
    private static void ObjectCheckForActionPostfix(SObject __instance, bool __state)
    {
        if (!__state || __instance.readyForHarvest.Value) return;

        if (__instance.name.Contains("Tapper") && ModEntry.Config.TappersRewardExp)
            Game1.player.gainExperience(Farmer.foragingSkill, 5);
        else if (__instance.name.Contains("Mushroom Box") && ModEntry.Config.MushroomBoxesRewardExp)
            Game1.player.gainExperience(Farmer.foragingSkill, 1);
    }

    /// <summary>Applies quality to aged bee house.</summary>
    [HarmonyTranspiler]
    private static IEnumerable<CodeInstruction>? ObjectCheckForActionTranspiler(
        IEnumerable<CodeInstruction> instructions, MethodBase original)
    {
        var helper = new ILHelper(original, instructions);

        /// Injected: heldObject.Value.Quality = this.GetQualityFromAge();
        /// After: heldObject.Value.preservedParentSheetIndex.Value = honey_type;

        try
        {
            helper
                .FindFirst(
                    new CodeInstruction(OpCodes.Ldstr, " Honey")
                )
                .FindNext(
                    new CodeInstruction(OpCodes.Ldfld,
                        typeof(SObject).RequireField(nameof(SObject.preservedParentSheetIndex)))
                )
                .RetreatUntil(
                    new CodeInstruction(OpCodes.Ldarg_0)
                )
                .GetInstructionsUntil(out var got, false, true,
                    new CodeInstruction(OpCodes.Callvirt)
                )
                .AdvanceUntil(
                    new CodeInstruction(OpCodes.Call,
                        typeof(Game1).RequirePropertyGetter(nameof(Game1.currentLocation)))
                )
                .Insert(got)
                .Insert(
                    new CodeInstruction(OpCodes.Ldarg_0),
                    new CodeInstruction(OpCodes.Call,
                        typeof(SObjectExtensions).RequireMethod(nameof(SObjectExtensions.GetQualityFromAge))),
                    new CodeInstruction(OpCodes.Callvirt,
                        typeof(SObject).RequirePropertySetter(nameof(SObject.Quality)))
                );
        }
        catch (Exception ex)
        {
            Log.E($"Failed improving honey quality with age.\nHelper returned {ex}");
            return null;
        }

        return helper.Flush();
    }

    #endregion harmony patches
}