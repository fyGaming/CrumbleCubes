using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseKicker : MonoBehaviour
{
    public Camera cam;
    public NavMeshSurface surface;
    public float fallingSpeed = 0f;
    CubeGenerator cubeGenerator;

    void Kick()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //kick hit object
            //Here should change the state of this cube instead of movign it straightforward
            hit.transform.position -= new Vector3(0, -0.5f, 0);

        }

    }

    void DeleteCube()

    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Cube")
            //kick hit object
            //Here should change the state of this cube instead of movign it straightforward
            {
                Destroy(hit.transform.gameObject);
                var x = hit.transform.position.x;
                var z = hit.transform.position.z;
                Debug.Log("kick x" + x + "kick z" + z);
                //cubeGenerator.Cubes[Mathf.RoundToInt(x), Mathf.RoundToInt(z)]
            }
        }
    }

    void FallCube()

    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Cube")
            //kick hit object
            //Here should change the state of this cube instead of movign it straightforward
            {
                //Destroy(hit.transform.gameObject);
                hit.transform.position -= new Vector3(0, fallingSpeed, 0);
                fallingSpeed += 0.01f;

                var x = hit.transform.position.x;
                var z = hit.transform.position.z;
                Debug.Log("kick x" + x + "kick z" + z);
                //cubeGenerator.Cubes[Mathf.RoundToInt(x), Mathf.RoundToInt(z)]
            }
        }
    }
    void FallingTest()
    {
        /// every Cube has its row and column, a certain spell can affect certain (x,y,rad) cubes
        /// every time a event associated with cubes removal, send a message to event manager to test falling/agent removal immediately
        /// 
        



    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FallCube();
            surface.BuildNavMesh();
        }
    }
}
