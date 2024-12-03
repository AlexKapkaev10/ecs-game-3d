using Leopotam.Ecs;
using UnityEngine;

namespace Project.Code.Scripts
{
    public sealed class CursorLockSystem : IEcsInitSystem
    {
        public void Init()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}