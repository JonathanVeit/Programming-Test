using UnityEngine;

namespace Unit.Movement
{
    public class WalkingUnit : MovingUnit
    {
        //[Header("Walk Settings")]

        protected override void Move()
        {
            rb.MovePosition(transform.position + DirToTarget() * moveSpeed * Time.deltaTime);
            SetAltitude(0);
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
}