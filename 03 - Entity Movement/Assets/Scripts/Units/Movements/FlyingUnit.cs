using UnityEngine;

namespace Unit.Movement
{
    public class FlyingUnit : MovingUnit
    {
        [Header("Fly Settings")]
        public float altitude = 2;

        protected override void Move()
        {
            rb.MovePosition(transform.position + DirToTarget() * moveSpeed * Time.deltaTime);
            SetAltitude(altitude);
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