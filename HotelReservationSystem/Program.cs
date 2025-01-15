
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Configrations;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HotelReservationSystem.Middlewares;

namespace HotelReservationSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(
                container =>
                {
                    container.RegisterModule<AutoFacModule>();
                });

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddMediatR(typeof(Program).Assembly);

            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
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

            app.UseMiddleware<GlobalErrorHandlerMiddleware>();
            
            app.UseMiddleware<TransactionMiddleware>();
            
            app.Run();
        }
    }
}
