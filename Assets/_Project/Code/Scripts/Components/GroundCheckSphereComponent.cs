using System;
using UnityEngine;

namespace Project.Code.Scripts
{
    [Serializable]
    public struct GroundCheckSphereComponent
    {
        public LayerMask GroundMask;
        public Transform GroundCheckSphere;
        public float GroundDistance;
        public bool IsGrounded;
    }
}