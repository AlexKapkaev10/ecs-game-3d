using System;
using UnityEngine;

namespace Project.Code.Scripts
{
    [Serializable]
    public struct MovableComponent
    {
        public CharacterController CharacterController;
        public Vector3 Velocity;
        public float Speed;
        public float Gravity;
    }
}