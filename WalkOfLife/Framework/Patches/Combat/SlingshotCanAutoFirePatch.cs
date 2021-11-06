﻿using System;
using System.Reflection;
using HarmonyLib;
using JetBrains.Annotations;
using StardewModdingAPI;
using StardewValley.Tools;

namespace TheLion.Stardew.Professions.Framework.Patches
{
	[UsedImplicitly]
	internal class SlingshotCanAutoFirePatch : BasePatch
	{
		/// <summary>Construct an instance.</summary>
		internal SlingshotCanAutoFirePatch()
		{
			Original = RequireMethod<Slingshot>(nameof(Slingshot.CanAutoFire));
			Prefix = new(AccessTools.Method(GetType(), nameof(SlingshotCanAutoFirePrefix)));
		}

		#region harmony patches

		/// <summary>Patch to allow auto-fire during Desperado super mode.</summary>
		[HarmonyPrefix]
		private static bool SlingshotCanAutoFirePrefix(Slingshot __instance, ref bool __result)
		{
			try
			{
				var who = __instance.getLastFarmerToUse();
				if (ModEntry.IsSuperModeActive && ModEntry.SuperModeIndex == Utility.Professions.IndexOf("Desperado"))
					__result = true;
				else
					__result = false;
				return false; // don't run original logic
			}
			catch (Exception ex)
			{
				ModEntry.Log($"Failed in {MethodBase.GetCurrentMethod()?.Name}:\n{ex}", LogLevel.Error);
				return true; // default to original logic
			}
		}

		#endregion harmony patches
	}
}