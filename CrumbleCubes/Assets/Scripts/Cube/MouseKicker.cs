using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseKicker : MonoBehaviour
{
    public Camera cam;

    void Kick()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //kick hit object
            hit.transform.position -= new Vector3(0, 10, 0);

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Kick();
        }
    }
}
