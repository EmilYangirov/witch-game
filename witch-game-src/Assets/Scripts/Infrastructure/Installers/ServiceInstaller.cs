using System;
using System.Threading;
using Infrastructure.Binders;
using Infrastructure.DataAccess.Repositories;
using Infrastructure.Services;
using Model.Characters;
using Model.LookItemsCollection;
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
           InstallServices(builder);
           InstallBinders();
           InstallViewModels(builder);
        }
        
        private void InstallBinders()
        {
            BinderFactory.RegisterBinder<TextBinder>();
            BinderFactory.RegisterBinder<BoolToMethodBinder>();
            BinderFactory.RegisterBinder<LookItemPropertiesBinder>();
        }
        
        private void InstallViewModels(IContainerBuilder builder)
        {
            builder.Register<DiamondsViewModel>(Lifetime.Scoped);
            builder.Register<GoldViewModel>(Lifetime.Scoped);
            builder.Register<LookItemViewModel>(Lifetime.Transient);
        }

        private void InstallServices(IContainerBuilder builder)
        {
            builder.Register<ISaveSystem, JsonSaveSystem>(Lifetime.Scoped);
            builder.Register<IDiamondRepository, DiamondRepository>(Lifetime.Scoped);
            builder.Register<IGoldRepository, GoldRepository>(Lifetime.Scoped);
            builder.Register<DiamondStorage>(Lifetime.Singleton);
            builder.Register<GoldStorage>(Lifetime.Singleton);
            builder.Register<ICharacterFactory, CharacterFactory>(Lifetime.Scoped);
            builder.Register<ICharacterRepository, CharacterRepository>(Lifetime.Singleton);
            builder.Register<ILookItemInvariantsCollection, LookItemInvariantsCollection>(Lifetime.Singleton);
        }
    }
}