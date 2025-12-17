using HarmonyLib;
using UnityEngine;

namespace LessScaryMannequins;

[HarmonyPatch(typeof(Mannequin), "Awake")]
class MannequinMeshPatch
{
    static void Postfix(Mannequin __instance)
    {
        ChangeMesh.Change(__instance.gameObject);
    }
}