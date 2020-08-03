using System.Collections;
using System.Collections.Generic;
using Unit.Movement;
using UnityEngine;

public class TeleportingUnit : MovingUnit
{
    [Header("Teleport Settings")]
    [SerializeField] float delay = 1;
    bool isTeleporting;

    protected override void Move()
    {
        if (!isTeleporting)
            StartCoroutine(Teleport());
    }

    IEnumerator Teleport() 
    {
        isTeleporting = true;
        SetAltitude(0);

        yield return new WaitForSeconds(delay);
        rb.MovePosition(currentTarget.position);
        isTeleporting = false;
    }

    protected override void OnReachedTarget()
    {
        Debug.Log("Reached target");
    }

    protected override void StayAtTarget()
    {
        Debug.Log("Stay at target");
    }
}
