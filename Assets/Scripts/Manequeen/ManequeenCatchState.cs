using UnityEngine;
using UnityEngine.SceneManagement;

public class ManequeenCatchState : ManequeenBaseState
{
    public override void EnterState(ManequeenStateManager manequeen)
    {
        manequeen.agent.isStopped = true;
        PlayerController.canMove = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public override void UpdateState(ManequeenStateManager manequeen)
    {
        
    }

    public override void ExitState(ManequeenStateManager manequeen)
    {
        
    }
}