using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit.Movement
{
    public enum UnitMovementTypes { Walk, Fly, Teleport }

    public static class UnitMovementMapping
    {
        public static Type GetMovementOfType(UnitMovementTypes type)
        {
            switch (type)
            {
                case UnitMovementTypes.Walk:
                    return typeof (WalkingUnit);
                case UnitMovementTypes.Fly:
                    return typeof(FlyingUnit);
                case UnitMovementTypes.Teleport:
                    return typeof(TeleportingUnit);
            }

            return null;
        }
    }
}