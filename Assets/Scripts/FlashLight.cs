using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] public float radius;
    [Range(0, 360)][SerializeField] public float angle;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private LayerMask obstuctionMask;
    [SerializeField] private TextMeshProUGUI text;
    bool manequeenOut;

    public static float timer = 120;

    private void Update()
    {
        FieldOfWievCheck();
        timer -= Time.deltaTime;
        if (timer <= 20)
        {
            text.gameObject.SetActive(true);
        }else text.gameObject.SetActive(false);
    }
    private void FieldOfWievCheck()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, targetMask);
        if (colliders.Length > 0)
        {
            foreach (var x in colliders)
            {
                if (x.TryGetComponent(out ManequeenStateManager manequeen))
                {
                    Vector3 targetPos = manequeen.transform.position;
                    Vector3 dirToTarget = new Vector3((targetPos - transform.position).x, 0, (targetPos - transform.position).z).normalized;

                    if (Vector3.Angle(transform.forward, dirToTarget) < angle / 2)
                    {
                        manequeen.inSight = true;
                    }
                    else if(Vector3.Angle(transform.forward, dirToTarget) >= angle / 2)
                    {
                        manequeen.inSight = false;
                    }
                }
            }
        }
    }
}
