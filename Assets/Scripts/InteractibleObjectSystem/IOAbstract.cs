using UnityEngine;

public abstract class IOAbstract : MonoBehaviour
{
    public Sprite icon;
    public virtual void NotifyInteractableObjects()
    {
        throw new System.NotImplementedException();
    }
}