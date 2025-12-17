using UnityEngine;

namespace LessScaryMannequins;

public static class ChangeMesh
{
    public static void Change(GameObject mannequin)
    {
        GameObject mannequinRenderObject = mannequin.transform.GetChild(0).GetChild(1).gameObject;
        mannequinRenderObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
        
        GameObject newMesh = GameObject.Instantiate(new GameObject(), mannequinRenderObject.transform);
        
        newMesh.AddComponent<MeshRenderer>();
        MeshFilter filter = newMesh.AddComponent<MeshFilter>();
        filter.mesh = MeshMaker.CreateCubeMesh();

        newMesh.transform.localScale = new Vector3(.01f, .01f, .02f);
        newMesh.transform.localPosition = new Vector3(0f, 0f, 0.01f);
    }

    public static void DestroyQuinn(GameObject mannequin)
    {
        GameObject.Destroy(mannequin.transform.GetChild(0).GetChild(1).GetChild(0).gameObject);
    }
}