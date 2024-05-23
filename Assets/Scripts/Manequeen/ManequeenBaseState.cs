using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ManequeenBaseState
{
    public virtual void EnterState(ManequeenStateManager manequeen) { }

    public virtual void ExitState(ManequeenStateManager manequeen) { }

    public virtual void UpdateState(ManequeenStateManager manequeen) { }
}
