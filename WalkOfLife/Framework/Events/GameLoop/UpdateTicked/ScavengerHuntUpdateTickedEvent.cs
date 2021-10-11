﻿using StardewModdingAPI.Events;

namespace TheLion.Stardew.Professions.Framework.Events
{
	public class ScavengerHuntUpdateTickedEvent : UpdateTickedEvent
	{
		/// <inheritdoc />
		public override void OnUpdateTicked(object sender, UpdateTickedEventArgs e)
		{
			ModEntry.ScavengerHunt.Update(e.Ticks);
		}
	}
}