using UnityEngine;
using System.IO;
using BepInEx;

namespace LessScaryMannequins;

public static class AssetLoader
{
    public static GameObject CopyTemplate;

    public static void Load()
    {   
        AssetBundle bundle = AssetBundle.LoadFromFile(Path.Combine(Paths.PluginPath, "LessScaryMannequins/resources/copy.bundle"));
        CopyTemplate = (GameObject)bundle.LoadAsset("Assets/Copy.prefab");
        bundle.Unload(false);
    }
}