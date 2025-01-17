﻿namespace DaLion.Overhaul.Modules.Professions.VirtualProperties;

#region using directives

using System.Runtime.CompilerServices;
using StardewValley.Monsters;

#endregion using directives

// ReSharper disable once InconsistentNaming
internal static class Monster_Stolen
{
    internal static ConditionalWeakTable<Monster, Holder> Values { get; } = new();

    internal static bool Get_Stolen(this Monster monster)
    {
        return Values.GetOrCreateValue(monster).Stolen;
    }

    internal static void Set_Stolen(this Monster monster, bool value)
    {
        Values.GetOrCreateValue(monster).Stolen = value;
    }

    internal class Holder
    {
        public bool Stolen { get; internal set; }
    }
}
