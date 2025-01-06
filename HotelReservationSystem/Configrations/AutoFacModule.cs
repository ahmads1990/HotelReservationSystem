

using Autofac;
using HotelReservationSystem.Data;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using HotelReservationSystem.RabbitMQ;

namespace HotelReservationSystem.Configrations;

public class AutoFacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(context =>
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            var configuration = context.Resolve<IConfiguration>();
            

            optionsBuilder
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                sqlOptions => sqlOptions.MigrationsAssembly(typeof(Context).Assembly.FullName))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
                .EnableSensitiveDataLogging();

            return new Context(optionsBuilder.Options);
        }).AsSelf().InstancePerLifetimeScope();

        builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(typeof(Program).Assembly)
            .Where(c => c.Name.EndsWith("Service") || c.Name.EndsWith("Repository"))
            .AsImplementedInterfaces().InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(typeof(Program).Assembly)
               .Where(c => c.Name.EndsWith("Mediator"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();

        builder.RegisterType<TokenHelper>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<RabbitMQPuublisherService>().AsSelf().InstancePerLifetimeScope();
    }
}
