using System.Linq;
using HarmonyLib;
using UnityEngine;

namespace LessScaryMannequins;

public static class ChangeMesh
{
    public static void Change(GameObject mannequin)
    {
        Plugin.Logger.LogInfo("CHANGING MANNEQUIN : " + mannequin.name);

        //new objects to paste
        GameObject birdie = Object.Instantiate(AssetLoader.CopyTemplate).transform.GetChild(0).gameObject;
        GameObject birdieArmature = birdie.transform.GetChild(0).gameObject;
        
        //old object to pull data
        GameObject quinn = mannequin.transform.GetChild(0).gameObject;
        GameObject quinnArmature = quinn.transform.GetChild(0).gameObject;


        Transform[] MappableBones = [];
        GameObject[] UnmappableBones = [];
        GameObject[] UnmappableParents = [];
        for (int i = 0; i < quinnArmature.transform.childCount; i++)
        {
            Transform bone = quinnArmature.transform.GetChild(i);
            if(birdieArmature.transform.Find(bone.name) == true)
            {
                Plugin.Logger.LogInfo("Mappable : " + bone.name);
                MappableBones.AddItem(bone.transform);
            }
            else
            {
                Plugin.Logger.LogInfo("Unmappable : " + bone.name);
                UnmappableBones.AddItem(bone.gameObject);
                UnmappableParents.AddItem(bone.parent.gameObject);
            }
        }
    }

    public static void DestroyQuinn(GameObject mannequin)
    {
        GameObject.Destroy(mannequin.transform.GetChild(1).gameObject);
    }
}