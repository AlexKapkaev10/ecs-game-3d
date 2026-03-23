using Leopotam.Ecs;
using Project.Services;

namespace Project.Code.Scripts
{
    public sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, DirectionComponent> _directionFilter = null;
        private readonly IInputService _inputService = null;
        
        public void Run()
        {
            foreach (var filter in _directionFilter)
            {
                ref var directionComponent = ref _directionFilter.Get2(filter);
                ref var direction = ref directionComponent.Direction;
                
                var move = _inputService.GetMoveAxis();

                direction.x = move.x;
                direction.z = move.y;
            }
        }
    }
}