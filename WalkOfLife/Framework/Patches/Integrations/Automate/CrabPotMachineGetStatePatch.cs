﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using JetBrains.Annotations;
using StardewModdingAPI;
using TheLion.Stardew.Common.Harmony;

namespace TheLion.Stardew.Professions.Framework.Patches
{
	[UsedImplicitly]
	internal class CrabPotMachineGetStatePatch : BasePatch
	{
		/// <summary>Construct an instance.</summary>
		internal CrabPotMachineGetStatePatch()
		{
			Original = AccessTools.Method(
				"Pathoschild.Stardew.Automate.Framework.Machines.Objects.CrabPotMachine:GetState");
			Transpiler = new(AccessTools.Method(GetType(), nameof(CrabPotMachineGetStateTranspiler)));
		}

		#region harmony patches

		/// <summary>Patch for conflicting Luremaster and Conservationist automation rules.</summary>
		[HarmonyTranspiler]
		private static IEnumerable<CodeInstruction> CrabPotMachineGetStateTranspiler(
			IEnumerable<CodeInstruction> instructions, MethodBase original)
		{
			var helper = new ILHelper(original, instructions);

			/// Removed: || !this.PlayerNeedsBait()

			try
			{
				helper
					.FindFirst(
						new CodeInstruction(OpCodes.Brtrue_S)
					)
					.RemoveUntil(
						new CodeInstruction(OpCodes.Call,
							AccessTools.Method(
								"Pathoschild.Stardew.Automate.Framework.Machines.Objects.CrabPotMachine:PlayerNeedsBait"))
					)
					.SetOpCode(OpCodes.Brfalse_S);
			}
			catch (Exception ex)
			{
				ModEntry.Log($"Failed while patching bait conditions for automated Crab Pots.\nHelper returned {ex}",
					LogLevel.Error);
				return null;
			}

			return helper.Flush();
		}

		#endregion harmony patches
	}
}