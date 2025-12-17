using UnityEngine;

namespace LessScaryMannequins;

static class MeshMaker
{
    public static Mesh CreateCubeMesh()
    {
        Mesh mesh = new();

        // Define vertices
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, 0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f)
        };

        // Define triangles
        int[] triangles = new int[]
        {
            0, 2, 1, 0, 3, 2, // back
            4, 5, 6, 4, 6, 7, // front
            0, 1, 5, 0, 5, 4, // bottom
            2, 3, 7, 2, 7, 6, // top
            0, 4, 7, 0, 7, 3, // left
            1, 2, 6, 1, 6, 5  // right
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();

        return mesh;
    }
}