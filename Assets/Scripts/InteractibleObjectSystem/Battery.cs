using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Battery : IOAbstract
{
    public Sprite sprite;
    private void Awake()
    {
        icon = sprite;
    }
    public override void NotifyInteractableObjects()
    {
        gameObject.SetActive(false);
    }
}
