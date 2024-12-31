

using Autofac;
using HotelReservationSystem.Data;
using HotelReservationSystem.Data.Repositories;

namespace HotelReservationSystem.Configrations;

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
