using UnityEngine;
using Unit.Movement;
using UnityEditor;
using System.Security.Cryptography;
using UnityEditor.SceneManagement;
using System;

namespace Unit
{
    public class Unit : MonoBehaviour
    {
        [Header("Unit Settings")]
        [SerializeField] UnitMovementTypes movementType = UnitMovementTypes.Walk;
        [SerializeField] MovingUnit currentMovement;

        UnitMovementTypes currentType;

        void Awake()
        {
            currentType = movementType;

            if (!currentMovement)
                SwitchMovement(movementType);
        }

        void SwitchMovement(UnitMovementTypes type)
        {
            MovingUnit newMovement = (MovingUnit) this.gameObject.AddComponent (UnitMovementMapping.GetMovementOfType(type));

            if (currentMovement)
                newMovement.Copy(currentMovement);
            
            Destroy(currentMovement);
            currentMovement = newMovement;

            currentType = type;
        }

        void OnValidate()
        {
            if (currentType != movementType && Application.isPlaying)
                SwitchMovement(movementType);
        }
    }
}
