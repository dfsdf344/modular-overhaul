﻿namespace DaLion.Stardew.Tweaks;

/// <summary>The mod user-defined settings.</summary>
public class ModConfig
{
    /// <summary>Tree sap quality should improve as the tree ages.</summary>
    public bool AgeSapTrees { get; set; } = true;

    /// <summary>If crab pots reward experience, so should tappers.</summary>
    public bool TappersRewardExp { get; set; } = true;

    /// <summary>Honey quality should improve as the hive gets older.</summary>
    public bool AgeBeeHouses { get; set; } = true;

    /// <summary>If wild forage rewards experience, berry bushes should qualify.</summary>
    public bool BerryBushesRewardExp { get; set; } = true;

    /// <summary>If regular trees can't grow in winter, neither should fruit trees.</summary>
    public bool PreventFruitTreeGrowthInWinter { get; set; } = true;

    /// <summary>Mead should take after Honey type.</summary>
    public bool KegsRememberHoneyFlower { get; set; } = true;

    /// <summary>Large input products should yield more processed output instead of higher quality.</summary>
    public bool LargeProducsYieldQuantityOverQuality { get; set; } = true;

    /// <summary>The visual style for different honey mead icons, if using BetterArtisanGoodIcons. Allowed values: 'ColoredBottles', 'ColoredCaps'.</summary>
    public string HoneyMeadStyle { get; set; } = "ColoredBottles";

    /// <summary>Bombs within any explosion radius are immediately triggered.</summary>
    public bool ExplosionTriggeredBombs { get; set; } = true;

    /// <summary>Extends the perks from Botanist/Ecologist profession to Ginger and Coconuts shaken off of palm trees.</summary>
    public bool ExtendedForagingPerks { get; set; } = true;
}