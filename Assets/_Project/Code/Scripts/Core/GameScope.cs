using Project.Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Code.Scripts.Core
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private InputServiceConfig _inputServiceConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<EcsStartup>()
                .As<IEcsStartup>();
            
            builder.Register<InputService>(Lifetime.Scoped)
                .As<IInputService>()
                .WithParameter(_inputServiceConfig);
        }
    }
}