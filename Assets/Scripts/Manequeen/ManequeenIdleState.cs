using UnityEngine;
public class ManequeenIdleState : ManequeenBaseState
{
    public override void EnterState(ManequeenStateManager manequeen)
    {
        Debug.Log("Idle enter");
    }

    public override void UpdateState(ManequeenStateManager manequeen)
    {
        Debug.Log("Idle");
        if (manequeen.inSight) { manequeen.SwitchState(manequeen.stunState); }
        if (Vector3.Distance(manequeen.transform.position, manequeen.player.position) < 5)
        {
            manequeen.SwitchState(manequeen.chaseState);
        }
    }
    public override void ExitState(ManequeenStateManager manequeen)
    {
        Debug.Log("Exit Idle State");
    }

    
}