﻿namespace DaLion.Stardew.Professions.Framework.Events.GameLoop.DayEnding;

#region using directives

using System;
using StardewValley;
using StardewModdingAPI.Events;

#endregion using directives

internal class PiperDayEndingEvent : DayEndingEvent
{
    private static readonly int _which = ModEntry.Manifest.UniqueID.GetHashCode() + (int) Profession.Piper;

    /// <inheritdoc />
    protected override void OnDayEndingImpl(object sender, DayEndingEventArgs e)
    {
        Game1.buffsDisplay.removeOtherBuff(_which);
        Array.Clear(ModEntry.PlayerState.Value.AppliedPiperBuffs, 0, 12);
        Disable();
    }
}