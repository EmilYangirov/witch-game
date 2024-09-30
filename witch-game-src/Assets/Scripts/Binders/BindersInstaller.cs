using MVVM;
using SharedKernel.Binder;
using VContainer;
using VContainer.Unity;

namespace Binders
{
    public class BindersInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            BinderFactory.RegisterBinder<TextBinder>();
        }
    }
}