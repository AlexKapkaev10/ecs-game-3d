using Leopotam.Ecs;
using UnityEngine;

namespace Project.Code.Scripts
{
    public sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<ModelComponent, MovableComponent, DirectionComponent> _movableFilter = null;

        public void Run()
        {
            foreach (var filter in _movableFilter)
            {
                ref var modelComponent = ref _movableFilter.Get1(filter);
                ref var movableComponent = ref _movableFilter.Get2(filter);
                ref var directionComponent = ref _movableFilter.Get3(filter);

                ref var direction = ref directionComponent.Direction;
                ref var transform = ref modelComponent.ModelTransform;

                ref var characterController = ref movableComponent.CharacterController;
                ref var speed = ref movableComponent.Speed;

                var rawDirection = (transform.right * direction.x) + (transform.forward * direction.z);
                
                ref var velocity = ref movableComponent.Velocity;
                velocity.y += movableComponent.Gravity * Time.deltaTime;

                characterController.Move(rawDirection * (speed * Time.deltaTime));
                characterController.Move(velocity * Time.deltaTime);
            }
        }
    }
}