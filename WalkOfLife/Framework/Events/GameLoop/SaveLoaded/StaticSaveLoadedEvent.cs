﻿using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Projectiles;
using System.Linq;
using TheLion.Stardew.Professions.Framework.Extensions;

namespace TheLion.Stardew.Professions.Framework.Events
{
	public class StaticSaveLoadedEvent : SaveLoadedEvent
	{
		/// <inheritdoc/>
		public override void OnSaveLoaded(object sender, SaveLoadedEventArgs e)
		{
			// load persisted mod data
			ModEntry.Data.Load();

			// set super mode
			ModEntry.SuperModeIndex = ModEntry.Data.ReadField<int>("SuperModeIndex");

			// check for mismatch between saved data and player professions
			if (ModEntry.SuperModeIndex < 0 && Game1.player.professions.Any(p => p is >= 26 and < 30))
				ModEntry.SuperModeIndex = Game1.player.professions.First(p => p is >= 26 and < 30);

			// subcribe player's profession events
			ModEntry.Subscriber.SubscribeEventsForLocalPlayer();

			if (!Game1.player.HasProfession("Desperado")) return;
			Projectile.boundingBoxHeight = 600;
			Projectile.boundingBoxWidth = 600;
		}
	}
}