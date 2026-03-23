using Leopotam.Ecs;
using Project.Services;
using UnityEngine;

namespace Project.Code.Scripts
{
    public sealed class MouseInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, MouseLookComponent> _playerFilters = null;
        private readonly IInputService _inputService = null;

        private float _axisX;
        private float _axisY;

        public void Run()
        {
            foreach (var filter in _playerFilters)
            {
                ref var lookComponent = ref _playerFilters.Get2(filter);
                
                var look = _inputService.GetLookDelta();
                _axisX += look.x;
                _axisY = Mathf.Clamp(
                    _axisY + look.y, 
                    _inputService.GetLookMin(), 
                    _inputService.GetLookMax());

                lookComponent.Direction.x = _axisX;
                lookComponent.Direction.y = _axisY;
            }
        }
    }
}