﻿namespace DaLion.Stardew.Professions.Framework.Events.GameLoop;

#region using directives

using Common.Events;
using StardewModdingAPI.Events;
using System.Linq;
using VirtualProperties;

#endregion using directives

[UsedImplicitly]
internal sealed class PrestigeTreasureHuntUpdateTickedEvent : UpdateTickedEvent
{
    /// <summary>Construct an instance.</summary>
    /// <param name="manager">The <see cref="ProfessionEventManager"/> instance that manages this event.</param>
    internal PrestigeTreasureHuntUpdateTickedEvent(ProfessionEventManager manager)
        : base(manager) { }

    /// <inheritdoc />
    protected override void OnUpdateTickedImpl(object? sender, UpdateTickedEventArgs e)
    {
        Game1.gameTimeInterval = 0;
        if (Farmer_HuntingTreasure.Values.AsEnumerable().All(pair => pair.Value.Value == false)) Disable();
    }
}