using Infrastructure.DataAccess.Repositories;
using Model.ShopSystem;
using MVVM;
using SharedKernel.Binder;
using SharedKernel.Infrastructure.SaveSystem;
using VContainer;
using VContainer.Unity;
using ViewModels;

namespace Infrastructure.Installers
{
    public class ServiceInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
           InstallBinders();
           InstallServices(builder);
           InstallViewModels(builder);
        }
        
        private void InstallBinders()
        {
            BinderFactory.RegisterBinder<TextBinder>();
        }
        
        private void InstallViewModels(IContainerBuilder builder)
        {
            builder.Register<DiamondsViewModel>(Lifetime.Scoped);
            builder.Register<GoldViewModel>(Lifetime.Scoped);
        }

        private void InstallServices(IContainerBuilder builder)
        {
            builder.Register<ISaveSystem, JsonSaveSystem>(Lifetime.Scoped);
            builder.Register<IDiamondRepository, DiamondRepository>(Lifetime.Scoped);
            builder.Register<IGoldRepository, GoldRepository>(Lifetime.Scoped);
            builder.Register<DiamondStorage>(Lifetime.Singleton);
            builder.Register<GoldStorage>(Lifetime.Singleton);
        }
    }
}