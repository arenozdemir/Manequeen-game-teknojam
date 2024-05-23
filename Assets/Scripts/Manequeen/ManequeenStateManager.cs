using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ManequeenStateManager : MonoBehaviour
{
    public NavMeshAgent agent;
    
    public ManequeenBaseState currentState;
    public ManequeenIdleState idleState = new ManequeenIdleState();
    public ManequeenChaseSate chaseState = new ManequeenChaseSate();
    public ManequeenCatchState catchState = new ManequeenCatchState();
    public ManequeenStunState stunState = new ManequeenStunState();
    
    public Transform player;
    public bool inSight;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        currentState = idleState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        Debug.Log(inSight);
        currentState.UpdateState(this);
        Debug.Log("State manager: " + currentState);
    }

    public void SwitchState(ManequeenBaseState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
}