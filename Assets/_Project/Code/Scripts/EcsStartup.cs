using System;
using Leopotam.Ecs;
using Project.Services;
using VContainer.Unity;
using Voody.UniLeo;

namespace Project.Code.Scripts
{
    public interface IEcsStartup : IStartable, ITickable, IDisposable
    {
        
    }
    
    public class EcsStartup : IEcsStartup
    {
        private readonly EcsWorld _world;
        private readonly EcsSystems _systems;
        
        private readonly IInputService _inputService;

        public EcsStartup(IInputService inputService)
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            
            _inputService = inputService;
        }

        public void Start()
        {
            _systems.ConvertScene();
            
            AddInjections();
            AddSystems();
            AddOneFrames();
            
            _systems.Init();
        }

        public void Tick()
        {
            _systems.Run();
        }

        public void Dispose()
        {
            if (_systems == null)
            {
                return;
            }
            
            _systems.Destroy();
            _world.Destroy();
        }

        private void AddSystems()
        {
            _systems.
                Add(new CursorLockSystem()).
                Add(new PlayerJumpSendEventSystem()).
                Add(new GroundCheckSystem()).
                Add(new PlayerInputSystem()).
                Add(new MouseInputSystem()).
                Add(new MouseLookSystem()).
                Add(new PlayerJumpSystem()).
                Add(new MovementSystem());
        }

        private void AddInjections()
        {
            _systems.Inject(_inputService);
        }

        private void AddOneFrames()
        {
            _systems.OneFrame<JumpEvent>();
        }
    }
}