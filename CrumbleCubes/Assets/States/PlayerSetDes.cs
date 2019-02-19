using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerSetDes : IState
{
    /// <summary>
    /// set player to the place where the mouse point to, things to ctor 
    /// player GO, mouse Pos
    /// </summary>
    private Camera cam;
    private NavMeshAgent agent;

    public PlayerSetDes(Camera cam, NavMeshAgent agent)
    {
        this.cam = cam;
        this.agent = agent;
    }

    public void Enter()
    {
        
    }

    public void Execute()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //Move Agent
            agent.SetDestination(hit.point);
        }
    }

    public void Exit()
    {
        
    }
}
