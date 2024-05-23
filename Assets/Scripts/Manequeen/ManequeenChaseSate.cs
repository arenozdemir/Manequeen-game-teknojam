using UnityEngine;
public class ManequeenChaseSate : ManequeenBaseState
{
    public override void EnterState(ManequeenStateManager manequeen)
    {
        SoundManager.PlaySound(SoundType.ManequeenWalking);
        manequeen.agent.isStopped = false;
        manequeen.agent.SetDestination(manequeen.player.position);
    }
    public override void UpdateState(ManequeenStateManager manequeen)
    {
        manequeen.agent.SetDestination(manequeen.player.position);
        if (manequeen.inSight) { manequeen.SwitchState(manequeen.stunState); }
        float distance = Vector3.Distance(manequeen.transform.position, manequeen.player.position);
        if (distance < 3f)
        {
            //CameraController.instance.SetNoiseAmplitude(1);
            if (distance < 1) manequeen.SwitchState(manequeen.catchState);
        }

    }
    public override void ExitState(ManequeenStateManager manequeen)
    {
        CameraController.instance.SetNoiseAmplitude(0);
    }
}