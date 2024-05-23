using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleTest : IOAbstract
{
    public void EKeyNotify()
    {
        throw new System.NotImplementedException();
    }

    //public void NotifyInteractableObjects()
    //{
    //    gameObject.SetActive(false);
    //}

    public void ShowIcon()
    {
        Debug.Log("Icon showed");
    }
}
