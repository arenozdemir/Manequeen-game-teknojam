using UnityEngine;
public class ManequeenStunState : ManequeenBaseState
{
    public override void EnterState(ManequeenStateManager manequeen)
    {
        manequeen.agent.isStopped = true;
        
    }
    public override void UpdateState(ManequeenStateManager manequeen)
    {
        Debug.Log("Stun");
        if (!manequeen.inSight)
        {
            manequeen.SwitchState(manequeen.idleState);
        }
    }

    public override void ExitState(ManequeenStateManager manequeen)
    {
        Debug.Log("EXit Stun");
    }
}