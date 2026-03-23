using Leopotam.Ecs;
using UnityEngine;

namespace Project.Code.Scripts
{
    public sealed class MouseInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, MouseLookComponent> _playerFilters = null;
        private readonly float _axisMin = -86f;
        private readonly float _axisMax = 75f;

        private float _axisX;
        private float _axisY;

        public void Run()
        {
            GetAxis();
            ClampAxis();
            
            foreach (var filter in _playerFilters)
            {
                ref var lookComponent = ref _playerFilters.Get2(filter);

                lookComponent.Direction.x = _axisX;
                lookComponent.Direction.y = _axisY;
            }
        }

        private void ClampAxis()
        {
            _axisX += Input.GetAxis("Mouse X");
            _axisY += Input.GetAxis("Mouse Y");
        }

        private void GetAxis()
        {
            _axisY = Mathf.Clamp(_axisY, _axisMin, _axisMax);
        }
    }
}