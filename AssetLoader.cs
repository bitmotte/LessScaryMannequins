using UnityEngine;
using System.IO;
using BepInEx;

namespace LessScaryMannequins;

public static class AssetLoader
{
    //public static GameObject CopyTemplate;

    public static void Load()
    {
        AssetBundle bundle = AssetBundle.LoadFromFile(Path.Combine(Paths.PluginPath, "LessScaryMannequins/resources/copy.bundle"));
        //bundle.LoadAsset("Assets/quinn.fbx");
        //bundle.LoadAsset("Assets/quinn.fbx[body]");
        //bundle.LoadAsset("Assets/Spin.anim");
        RuntimeAnimatorController animatorController = (RuntimeAnimatorController)bundle.LoadAsset("Assets/TestAssetAnimator.controller");
        GameObject CopyTemplate = (GameObject)bundle.LoadAsset("Assets/TestBundleAsset.prefab");
        
        GameObject.Instantiate(CopyTemplate);
        Plugin.Logger.LogInfo(animatorController);

        bundle.Unload(true);
    }
}