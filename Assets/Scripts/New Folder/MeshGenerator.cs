using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    public GameObject spherePrefab;
    public int rows = 5;
    public int columns = 5;
    public float spacing = 5f;

    void Start()
    {
        GenerateMesh();
    }

    void GenerateMesh()
    {
        GameObject[,] spheres = new GameObject[rows, columns];

        // Instantiate 
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Vector3 position = new Vector3(i * spacing, j * spacing, 0f);
                GameObject sphere = Instantiate(spherePrefab, position, Quaternion.identity);
                spheres[i, j] = sphere;
            }
        }

        for (int i = 0; i < rows - 2; i++)
        {
            for (int j = 0; j < columns - 2; j++)
            {
                // structual
                SpringOscillation springOscillation = spheres[i, j].AddComponent<SpringOscillation>();
                springOscillation.connectedObject = spheres[i + 1, j].transform;

                SpringOscillation jSpringOscillation = spheres[i, j].AddComponent<SpringOscillation>();
                jSpringOscillation.connectedObject = spheres[i, j + 1].transform;

                // shear
                SpringOscillation shearSpringOscillation = spheres[i, j].AddComponent<SpringOscillation>();
                shearSpringOscillation.connectedObject = spheres[i + 1, j + 1].transform;

                SpringOscillation shear2SpringOscillation = spheres[i + 1, j].AddComponent<SpringOscillation>();
                shear2SpringOscillation.connectedObject = spheres[i, j + 1].transform;

                // diagonal flexion
                SpringOscillation flexionSpringOscillation = spheres[i, j].AddComponent<SpringOscillation>();
                flexionSpringOscillation.connectedObject = spheres[i + 2, j].transform;

                SpringOscillation flexion2SpringOscillation = spheres[i, j].AddComponent<SpringOscillation>();
                flexion2SpringOscillation.connectedObject = spheres[i, j + 2].transform;
            }
        }
    }
}
