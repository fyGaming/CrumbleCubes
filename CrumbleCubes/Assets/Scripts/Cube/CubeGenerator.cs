using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CubeGenerator : MonoBehaviour
{
    public NavMeshSurface surface;

    void GenerateCubes()
    {
        int x = 0;
        for (int _x = 0; _x < 20; _x++)
        {
            int z = 0;
            for (int _z = 0; _z < 20; _z++)
            {
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
                meshRenderer.material.shader = Shader.Find("Standard");
                meshRenderer.material.SetColor("_Color", Color.white);
                gameObject.transform.localScale = new Vector3(1f,1f,1f);
                gameObject.transform.position = new Vector3(x, 0, z);
                z++;
                Debug.Log(z);
            }
            x++;
            Debug.Log(x);
        }

    }

    private void Start()
    {
        GenerateCubes();
        surface.BuildNavMesh();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GenerateCubes();
        }
    }


}
