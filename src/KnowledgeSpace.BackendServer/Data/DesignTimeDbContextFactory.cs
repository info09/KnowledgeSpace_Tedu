using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace KnowledgeSpace.BackendServer.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").AddJsonFile($"appsettings.{env}.json").Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectString);
            return new ApplicationDbContext(builder.Options);
        }
    }
}
