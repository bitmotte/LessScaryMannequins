using UnityEngine;

namespace LessScaryMannequins;

public static class ChangeMesh
{
    public static void Change(GameObject mannequin)
    {
        Object.Destroy(mannequin.transform.GetChild(0).gameObject);

        GameObject copy = Object.Instantiate(AssetLoader.CopyTemplate, mannequin.transform);
        GameObject copyMesh = copy.transform.GetChild(0).gameObject;
        copyMesh.transform.parent = mannequin.transform;
        copyMesh.transform.localScale = new Vector3(3.2f,3.2f,3.2f);

        Animator copyController = copy.GetComponent<Animator>();
        Animator mannequinController = mannequin.GetComponent<Animator>();
        mannequinController.avatar = copyController.avatar;
        mannequinController.runtimeAnimatorController = copyController.runtimeAnimatorController;

        Object.Destroy(copy);
    }

    public static void DestroyQuinn(GameObject mannequin)
    {
        GameObject.Destroy(mannequin.transform.GetChild(0).GetChild(1).GetChild(0).gameObject);
    }
}