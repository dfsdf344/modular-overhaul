﻿namespace DaLion.Common.Harmony;

#region using directives

using Attributes;
using Extensions.Reflection;
using HarmonyLib;
using LinqFasterer;
using System;
using System.Diagnostics;
using System.Reflection;

#endregion using directives

/// <summary>Instantiates and applies <see cref="HarmonyPatch"/> classes in the assembly.</summary>
internal class Harmonizer
{
    /// <inheritdoc cref="Harmony"/>
    private readonly Harmony _Harmony;
    private readonly IModRegistry _ModRegistry;

    /// <summary>Construct an instance.</summary>
    /// <param name="uniqueID">The unique ID of the declaring mod.</param>
    /// /// <param name="modRegistry">API for fetching metadata about loaded mods.</param>
    internal Harmonizer(IModRegistry modRegistry, string uniqueID)
    {
        _Harmony = new(uniqueID);
        _ModRegistry = modRegistry;
    }

    /// <summary>Instantiate and apply one of every <see cref="IHarmonyPatch" /> class in the assembly using reflection.</summary>
    internal void ApplyAll()
    {
        var sw = new Stopwatch();
        sw.Start();

        Log.D("[Harmonizer]: Gathering patches...");
        var patchTypes = AccessTools
            .GetTypesFromAssembly(Assembly.GetAssembly(typeof(IHarmonyPatch)))
            .WhereF(t => t.IsAssignableTo(typeof(IHarmonyPatch)) && !t.IsAbstract)
            .ToArrayF();

        Log.D($"[Harmonizer]: Found {patchTypes.Length} patch classes. Applying patches...");
        foreach (var p in patchTypes)
        {
            try
            {
#if RELEASE
                var debugOnlyAttribute =
                    (DebugOnlyAttribute?)p.GetCustomAttributes(typeof(DebugOnlyAttribute), false).FirstOrDefault();
                if (debugOnlyAttribute is not null) continue;
#endif

                var deprecatedAttr =
                    (DeprecatedAttribute?)p.GetCustomAttributes(typeof(DeprecatedAttribute), false).FirstOrDefaultF();
                if (deprecatedAttr is not null) continue;

                var integrationAttr = (RequiresModAttribute?)p.GetCustomAttributes(typeof(RequiresModAttribute), false).FirstOrDefaultF();
                if (integrationAttr is not null)
                {
                    if (!_ModRegistry.IsLoaded(integrationAttr.UniqueID))
                    {
                        Log.D(
                            $"[Harmonizer]: The target mod {integrationAttr.UniqueID} is not loaded. {p.Name} will be ignored.");
                        continue;
                    }

                    if (!string.IsNullOrEmpty(integrationAttr.Version) &&
                        _ModRegistry.Get(integrationAttr.UniqueID)!.Manifest.Version.IsOlderThan(
                            integrationAttr.Version))
                    {
                        Log.W(
                            $"[Harmonizer]: The integration patch {p.Name} will be ignored because the installed version of {integrationAttr.UniqueID} is older than minimum supported version." +
                            $" Please update {integrationAttr.UniqueID} in order to enable integrations with {_Harmony.Id}.");
                        continue;
                    }
                }

                var patch = (IHarmonyPatch?)p
                    .GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, Type.EmptyTypes, null)
                    ?.Invoke(Array.Empty<object>());
                if (patch is null) ThrowHelper.ThrowMissingMethodException("Didn't find internal parameter-less constructor.");

                patch.Apply(_Harmony);
                Log.D($"[Harmonizer]: Applied {p.Name} to {patch.Target!.GetFullName()}.");
            }
            catch (MissingMethodException ex)
            {
                Log.W($"[Harmonizer]: {ex.Message} {p.Name} will be ignored.");
            }
            catch (Exception ex)
            {
                Log.E($"[Harmonizer]: Failed to apply {p.Name}.\nHarmony returned {ex}");
            }
        }

        sw.Stop();
        Log.D($"[Harmonizer]: Patching completed in {sw.ElapsedMilliseconds}ms.");
    }
}