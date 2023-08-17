using Autofac;
using Module = Autofac.Module;
using NLayerApp.Repository;
using NLayerApp.Service.Mapping;
using System.Reflection;
using NLayerApp.Repository.Repositories;
using NLayerApp.Core.Repositories;
using NLayerApp.Service.Services;
using NLayerApp.Core.Services;
using NLayerApp.Repository.UnitOfWorks;
using NLayerApp.Core.UnitOfWorks;

namespace NLayerApp.Web.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork));

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();


            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
