﻿using StardewModdingAPI.Events;
using TheLion.Stardew.Professions.Framework.Util;

namespace TheLion.Stardew.Professions.Framework.Events
{
	public class ArrowPointerUpdateTickedEvent : UpdateTickedEvent
	{
		/// <inheritdoc/>
		public override void OnUpdateTicked(object sender, UpdateTickedEventArgs e)
		{
			HUD.Pointer ??= new ArrowPointer();
			if (e.Ticks % 4 == 0) HUD.Pointer.Bob();
		}
	}
}