using Leopotam.Ecs;
using UnityEngine;

namespace Project.Code.Scripts
{
    sealed class PlayerJumpSendEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, JumpComponent> _playerFilters = null;
        
        public void Run()
        {
            if (!Input.GetKeyDown(KeyCode.Space))
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