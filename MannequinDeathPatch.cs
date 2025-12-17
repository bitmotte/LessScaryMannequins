using HarmonyLib;
using UnityEngine;

namespace LessScaryMannequins;

[HarmonyPatch(typeof(Mannequin), "OnDeath")]
class MannequinDeathPatch
{
    static void Prefix(Mannequin __instance)
    {
        ChangeMesh.DestroyQuinn(__instance.gameObject);
    }
}