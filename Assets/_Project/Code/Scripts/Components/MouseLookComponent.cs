using System;
using UnityEngine;

namespace Project.Code.Scripts
{
    [Serializable]
    public struct MouseLookComponent
    {
        public Transform CameraTransform;
        [HideInInspector] public Vector3 Direction;
        [Range(0, 2)] public float MouseSensitivity;
    }
}