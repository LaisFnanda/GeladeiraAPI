using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Context;
using Repository.Interface;
using Repository.RepositoryClasses;
using Services.Interfaces;
using Services.ServicesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DIP
{
    public class Initializer
    {
        public static void Configure(IServiceCollection services, string connection)
        {
            services.AddDbContext<ItemContext>(options => options.UseSqlServer(connection));

            services.AddScoped(typeof(IRepository<Item>), typeof(ItemRepository));
            services.AddScoped(typeof(IItemServices<Item>), typeof(ItemService));
        }
    }
}
