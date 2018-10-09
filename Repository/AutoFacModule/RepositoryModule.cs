using App2c2pTest.Data;
using App2c2pTest.Repository;
using App2c2pTest.Repository.Interface;
using Autofac;
using NACC.Repository.Interface;

namespace NACC.Repository.AutoFacModule
{
    public class RepositoryModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {


            builder.RegisterType<App2c2pContext>().InstancePerLifetimeScope();
           

            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();
          
            builder.RegisterAssemblyTypes(typeof(IAutoDependencyRegister).Assembly)
                .AssignableTo<IAutoDependencyRegister>()
                .As<IAutoDependencyRegister>()
                .AsImplementedInterfaces().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}