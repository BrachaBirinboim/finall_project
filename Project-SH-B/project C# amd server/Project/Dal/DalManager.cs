using Dal.DalApi;
using Dal.Models;
using Dal.Services;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DalManager
    {
       public IClientService Clients { get; set; }
      public IDietitianService Dietitians { get; }
        public IMeetingService Meetings { get; }
        public DalManager(string connStr)
        {
            ServiceCollection services = new ServiceCollection();
         
            services.AddDbContext<NutritionInstitute>(opt => opt.UseSqlServer(connStr));
            //DBActions db = new DBActions(/*builder.*/Configuration);
            //string connStr = db.GetConnectionString("NutritionContext");
            //Services.AddDbContext<NutritionContext>(opt => opt.UseSqlServer(connStr));
            services.AddScoped<IDietitianService, DietitianService>();
            services.AddScoped<IMeetingService,MeetingService>();
            services.AddScoped<IClientService, ClientService>();
            ServiceProvider servicesProvider = services.BuildServiceProvider();
            Dietitians= servicesProvider.GetRequiredService<IDietitianService>();
            Meetings= servicesProvider.GetRequiredService<IMeetingService>();
            Clients = servicesProvider.GetRequiredService<IClientService>();
        }
    }
}
