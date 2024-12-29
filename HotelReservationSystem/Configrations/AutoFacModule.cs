

using Autofac;
using FOOD_APP_JSB_2.Data;
using FOOD_APP_JSB_2.Data.Repositories;

namespace FOOD_APP_JSB_2.Configrations;

public class AutoFacModule: Module
{
    public AutoFacModule()
    {

    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Context>().InstancePerLifetimeScope();
        builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(typeof(Program).Assembly)
            .Where(c => c.Name.EndsWith("Service") || c.Name.EndsWith("Repository"))
            .AsImplementedInterfaces().InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(typeof(Program).Assembly)
               .Where(c => c.Name.EndsWith("Mediator"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();
    }
}