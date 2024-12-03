using Leopotam.Ecs;
using UnityEngine;

namespace Project.Code.Scripts
{
    public sealed class MouseLookSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag> _playerFilter = null;
        private readonly EcsFilter<PlayerTag, ModelComponent, MouseLookComponent> _mouseLookFilter = null;
        
        private Quaternion startTransformRotation;
        
        public void Init()
        {
            foreach (var filter in _playerFilter)
            {
                ref var entity = ref _playerFilter.GetEntity(filter);
                ref var model = ref entity.Get<ModelComponent>();

                startTransformRotation = model.ModelTransform.rotation;
            }
        }

        public void Run()
        {
            foreach (var filter in _mouseLookFilter)
            {
                ref var model = ref _mouseLookFilter.Get2(filter);
                ref var lookComponent = ref _mouseLookFilter.Get3(filter);

                var axisX = lookComponent.Direction.x;
                var axisY = -lookComponent.Direction.y;
                
                var rotateX = 
                    Quaternion.AngleAxis(axisX, Vector3.up * (Time.deltaTime * lookComponent.MouseSensitivity));
                var rotateY = 
                    Quaternion.AngleAxis(axisY, Vector3.right * (Time.deltaTime * lookComponent.MouseSensitivity));
                
                model.ModelTransform.rotation = startTransformRotation * rotateX;
                lookComponent.CameraTransform.rotation = model.ModelTransform.rotation * rotateY;
            }
        }
    }
}