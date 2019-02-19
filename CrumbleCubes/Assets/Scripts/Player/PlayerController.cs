using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private StateMachine stateMachine = new StateMachine();
    public Camera cam;
    public NavMeshAgent agent;
    public float fallingSpeed = 0f;
    CubeGenerator cubeGenerator;
    bool falling = false;


    void Start()
    {
        this.stateMachine.ChangeState(new PlayerIdle());

    }

    void Update()
    {
        this.stateMachine.ExecuteStateUpdate();

        if (Input.GetMouseButtonDown(1))
        {
            this.stateMachine.ChangeState(new PlayerSetDes(cam, agent));
            //this.stateMachine.SwitchToPreviousState();
        }

        /*  working without state machine
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray =  cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Move Agent
                agent.SetDestination(hit.point);

            }
        }
        */

    }

    void FixedUpdate()
    {
        FallingTest();  ///Test if falling every physical frame

        if (Input.GetKeyDown(KeyCode.F))
        {
            MakeFall();
            
        }

        if (falling == true)
        {
            //agent.isStopped = true;
            //agent.ResetPath();
            Destroy(GetComponent("NavMeshAgent"));   /////*** Important for falling ***///
            this.transform.position -= new Vector3(0, fallingSpeed, 0);
            fallingSpeed += 0.01f; 
        }

        TestGameOver();

    }

    void MakeFall()
    {
        falling = true;
    }

    void TestGameOver()
    {
        if (this.transform.position.y <= -100f)
        {
            Debug.Log("GameOver");
            Destroy(this.gameObject);
        }

    }

    void FallingTest()
    {
        /// every Cube has its row and column, a certain spell can affect certain (x,y,rad) cubes
        /// every time a event associated with cubes removal, send a message to event manager to test falling/agent removal immediately
        /// Need to update Cubes first


        float x = this.transform.position.x;
        float z = this.transform.position.z;
    /*
        if (cubeGenerator.Cubes[Mathf.FloorToInt(x), Mathf.FloorToInt(z)] == null)
        {
            falling = true;
        }

        else falling = false;   
    */
    }


}
