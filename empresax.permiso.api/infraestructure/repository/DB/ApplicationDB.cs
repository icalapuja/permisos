using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


namespace empresax.permiso.api.infraestructure.repository.DB
{
    public class ApplicationDB
    {
        private static IConfiguration AppSetting = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
        public static DbContextOptions<ApplicationDbContext> GetDBContext()
        {
            var OptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            OptionsBuilder.UseNpgsql(AppSetting["ConnectionString:DB_EMPRESAX"]);
            return OptionsBuilder.Options;
        }

    }
}