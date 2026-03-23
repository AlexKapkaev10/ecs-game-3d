using Leopotam.Ecs;
using Project.Services;

namespace Project.Code.Scripts
{
    sealed class PlayerJumpSendEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, JumpComponent> _playerFilters = null;
        private readonly IInputService _inputService = null;
        
        public void Run()
        {
            if (!_inputService.IsJumpButtonPressed())
            {
                return;
            }
            
            foreach (var filter in _playerFilters)
            {
                ref var entity = ref _playerFilters.GetEntity(filter);
                entity.Get<JumpEvent>();
            }
        }
    }
}