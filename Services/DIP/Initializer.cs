using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Repository.Context;
using Repository.Interface;
using Repository.RepositoryClasses;
using Services.Interfaces;
using Services.ServicesClasses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace Services.DIP
{
    public class Initializer
    {
        public static void Configure(IServiceCollection services, ConfigurationManager configuration)
        {
            string? key = configuration.GetValue<string>("Key");

            services.AddDbContext<ItemContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });            

            services.AddScoped(typeof(IRepository<Item>), typeof(ItemRepository));
            services.AddScoped(typeof(IItemServices<Item>), typeof(ItemService));
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = false,
                   ValidateAudience = false,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = key is not null ? new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)) : null
               };
           });
            services.AddEndpointsApiExplorer();
        }
    }
}
