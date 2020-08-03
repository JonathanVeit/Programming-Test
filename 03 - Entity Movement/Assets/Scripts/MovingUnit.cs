using System.Collections;
using UnityEngine;
using Photon.Pun;
using System.Resources;

namespace Unit.Movement
{
    public enum MovingState { Waiting, Moving, ReachedTarget }
    public enum MovingType { StopAtTarget, Continues }
    public enum ControlType { isLocal, isSycned };

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PhotonView))]
    public abstract class MovingUnit : MonoBehaviour
    {
        protected Rigidbody rb;
        protected PhotonView pv;

        [Header("Movement Settings")]
        public float moveSpeed;
        public float stoppingDistance;

        [HideInInspector] public Transform currentTarget;
        [HideInInspector] public MovingState currentState = MovingState.Waiting;
        [HideInInspector] public MovingType currentMovingType;
        [HideInInspector] public ControlType currentControlType;
        
        bool reachedTarget = false;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            pv = GetComponent<PhotonView>();

            if (pv.IsMine)
            {
                currentControlType = ControlType.isLocal;
            }
            else
            {
                currentControlType = ControlType.isSycned;
            }
        }

        public void Copy (MovingUnit unit, bool keepTarget = true)
        {
            moveSpeed = unit.moveSpeed;
            stoppingDistance = unit.stoppingDistance;

            if (keepTarget)
                SetTarget(unit.currentTarget, unit.currentMovingType);
        }

        #region Movement

        public void SetTarget(Transform target, MovingType type = MovingType.StopAtTarget)
        {
            if (target != null && currentControlType == ControlType.isLocal)
            {
                this.currentTarget = target;
                this.currentMovingType = type;
                StartCoroutine(UpdateMoving());
            }
        }

        public void StopMoving() 
        {
            currentState = MovingState.ReachedTarget;
            currentTarget = null;
            StopAllCoroutines();
        }

        protected void SetAltitude(float altitude) 
        {
            var targetPos = transform.position;
            targetPos.y = altitude;
            transform.position = targetPos;
        }

        IEnumerator UpdateMoving() 
        {
            currentState = MovingState.Moving;

            while (true)
            {
                // move update
                if (DistToTarget() > stoppingDistance)
                {
                    reachedTarget = false;
                    Move();
                }
                // reach target at continues
                else if (currentMovingType == MovingType.Continues)
                {
                    if (!reachedTarget)
                    {
                        OnReachedTarget();
                        reachedTarget = true;
                    }
                    else
                    {
                        StayAtTarget();
                    }
                }
                // reach target and stop
                else if (currentMovingType == MovingType.StopAtTarget)
                    break;

                yield return null;
            }

            OnReachedTarget();
            StopMoving();
        }

        protected abstract void Move();

        protected virtual void OnReachedTarget() { }

        protected virtual void StayAtTarget() { }

        #endregion

        #region Protected Member      

        protected Vector3 DirToTarget()
        {
            var posH = new Vector3(transform.position.x, 0, transform.position.z);
            var tartPosH = new Vector3(currentTarget.position.x, 0, currentTarget.position.z);

            return (tartPosH - posH).normalized;
        }

        protected float DistToTarget()
        {
            var posH = ToVector2(transform.position);
            var tartPosH = ToVector2(currentTarget.position);

            return Vector2.Distance(posH, tartPosH);
        }

        protected MovingState State
        {
            get
            {
                return currentState;
            }
        }

        #endregion

        #region Calculations

        Vector2 ToVector2(Vector3 pos)
        {
            return new Vector2(pos.x, pos.z);
        }

        #endregion
    }
}