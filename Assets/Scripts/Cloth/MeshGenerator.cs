using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    public GameObject spherePrefab;
    public int rows = 50;
    public int columns = 20;
    public float spacing = 5f;
    public Material blackMaterial; // Material for the black color
    public Material whiteMaterial; // Material for the white color
    public Material greenMaterial; // Material for the green color
    public Material redMaterial; // Material for the red triangle

    public float timeScale = 1.0f;

    public float springConst = 1f;

    private void Update()
    {
        Time.timeScale = timeScale;
        
    }
    void Start()
    {
        //GenerateMesh();
    }

    [ContextMenu("Regenerate")]
    public void Regenerate()
    {
        DeleteAllChildren();
        GenerateMesh();
    }

    [ContextMenu("Delete All")]
    public void DeleteAllChildren()
    {
        int childCount = transform.childCount;

        for (int i = childCount - 1; i >= 0; i--)
        {
            Transform child = transform.GetChild(i);
            DestroyImmediate(child.gameObject);
        }
    }

    [ContextMenu("Generate Mesh")]
    public void GenerateMesh()
    {
        GameObject[,] spheres = new GameObject[rows, columns];

        // Calculate the size of each flag stripe
        float stripeWidth = columns / 3f;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Vector3 position = new Vector3(i * spacing, j * spacing, 0f);
                GameObject sphere = Instantiate(spherePrefab, position, Quaternion.identity);
                sphere.transform.SetParent(transform);
                sphere.name = $"Sphere_{i}_{j}";
                spheres[i, j] = sphere;

                //sphere.AddComponent<Rigidbody>();
                //sphere.GetComponent<Rigidbody>().useGravity = false;

                ApplyFlagColor(stripeWidth, i,j, sphere);
            }
        }





        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // structural
                if (i < rows - 1)
                {
                    SpringOscillation springOscillation = spheres[i, j].AddComponent<SpringOscillation>();
                    springOscillation.connectedObject = spheres[i + 1, j].transform;
                }

                if (j < columns - 1)
                {
                    SpringOscillation jSpringOscillation = spheres[i, j].AddComponent<SpringOscillation>();
                    jSpringOscillation.connectedObject = spheres[i, j + 1].transform;
                }

                // shear
                if (i < rows - 1 && j < columns - 1)
                {
                    SpringOscillation shearSpringOscillation = spheres[i, j].AddComponent<SpringOscillation>();
                    shearSpringOscillation.connectedObject = spheres[i + 1, j + 1].transform;
                }

                // diagonal flexion
                if (i < rows - 2)
                {
                    SpringOscillation flexionSpringOscillation = spheres[i, j].AddComponent<SpringOscillation>();
                    flexionSpringOscillation.connectedObject = spheres[i + 2, j].transform;
                }

                if (j < columns - 2)
                {
                    SpringOscillation flexion2SpringOscillation = spheres[i, j].AddComponent<SpringOscillation>();
                    flexion2SpringOscillation.connectedObject = spheres[i, j + 2].transform;
                }
            }
        }

    }

    private void ApplyFlagColor(float stripeWidth, int i, int j, GameObject sphere)
    {
        // Determine the color of the sphere based on its position
       
        
        if (j < stripeWidth)
        {
            sphere.GetComponent<Renderer>().material = greenMaterial;
        }
        else if (j < 2 * stripeWidth)
        {
            sphere.GetComponent<Renderer>().material = whiteMaterial;
        }
        else
        {
            sphere.GetComponent<Renderer>().material = blackMaterial;
        }

        int midRow= rows / 2;

        //if ( (i<=j)  ) // This condition represents the area of the red triangle
        //{
        //    sphere.GetComponent<Renderer>().material = redMaterial;
        //}
        
        if ((i <= j) &&(i+j<columns)  ) // This condition represents the area of the red triangle
        {
            sphere.GetComponent<Renderer>().material = redMaterial;
        }
    }
}