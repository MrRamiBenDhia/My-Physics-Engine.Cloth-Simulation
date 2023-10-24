using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertices : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LogCubeVertices();

        int[] polygonIndices = { 0, 1, 2, 3 }; // Indices of vertices in a polygon (for example, the first one).
        LogPolygonPlaneEquation(polygonIndices);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void LogCubeVertices()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter != null)
        {
            Mesh mesh = meshFilter.mesh;
            Vector3[] vertices = mesh.vertices;
            Vector3[] worldVertices = new Vector3[vertices.Length];

            Transform cubeTransform = transform;

            for (int i = 0; i < vertices.Length; i++)
            {
                worldVertices[i] = cubeTransform.TransformPoint(vertices[i]);
                Debug.Log("Vertex " + i + " Position: " + worldVertices[i]);
            }
        }
    }

    void LogPolygonPlaneEquation(int[] indices)
    {
        if (indices.Length < 3)
        {
            Debug.LogError("Polygon must have at least 3 vertices.");
            return;
        }

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter != null)
        {
            Mesh mesh = meshFilter.mesh;
            Vector3[] vertices = mesh.vertices;

            Vector3 edge1 = vertices[indices[1]] - vertices[indices[0]];
            Vector3 edge2 = vertices[indices[2]] - vertices[indices[0]];

            Vector3 normal = Vector3.Cross(edge1, edge2).normalized;

            // D can be calculated using the dot product of the normal and any point on the plane.
            float D = -Vector3.Dot(normal, vertices[indices[0]]);

            // Log the plane equation.
            Debug.Log("Plane Equation: " + normal.x + "x + " + normal.y + "y + " + normal.z + "z + " + D + " = 0");
        }
        else
        {
            Debug.LogError("MeshFilter component not found on the GameObject.");
        }
    }
}
