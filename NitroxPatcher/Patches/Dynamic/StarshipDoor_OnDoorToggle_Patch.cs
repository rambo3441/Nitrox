﻿using System.Reflection;
using HarmonyLib;
using NitroxClient.GameLogic;
using NitroxClient.MonoBehaviours;
using NitroxModel.Core;
using NitroxModel.DataStructures;
using NitroxModel.DataStructures.GameLogic.Entities.Metadata;

namespace NitroxPatcher.Patches.Dynamic
{
    class StarshipDoor_OnDoorToggle_Patch : NitroxPatch, IDynamicPatch
    {
        public static readonly MethodInfo TARGET_METHOD = typeof(StarshipDoor).GetMethod("OnDoorToggle", BindingFlags.Instance | BindingFlags.NonPublic);

        public static void Postfix(StarshipDoor __instance)
        {
            NitroxId id = NitroxEntity.GetId(__instance.gameObject);
            StarshipDoorMetadata starshipDoorMetadata = new StarshipDoorMetadata(__instance.doorLocked, __instance.doorOpen);
            Entities entities = NitroxServiceLocator.LocateService<Entities>();

            entities.BroadcastMetadataUpdate(id, starshipDoorMetadata);
        }

        public override void Patch(Harmony harmony)
        {
            PatchPostfix(harmony, TARGET_METHOD);
        }
    }
}
