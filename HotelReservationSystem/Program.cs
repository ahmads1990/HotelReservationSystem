
using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Configrations;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Data.Repositories;
using MediatR;
using System.Text;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace HotelReservationSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(container => container.RegisterModule(new AutoFacModule()));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddMediatR(typeof(Program).Assembly);

            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterType<TokenHelper>().AsSelf().InstancePerLifetimeScope();
            });
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var jwtSettings = configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings.GetValue<string>("SecretKey"));

            builder.Services.AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opts =>
            {
                opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidIssuer = jwtSettings.GetValue<string>("Issuer"),
                    ValidAudience = jwtSettings.GetValue<string>("Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                };
            });

            builder.Services.AddAuthorization();


            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            AutoMapperService._mapper = app.Services.GetService<IMapper>();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
