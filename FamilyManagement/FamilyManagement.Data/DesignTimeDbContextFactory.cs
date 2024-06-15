using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FamilyManagement.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FamilyManagementDbContext>
    {
        public FamilyManagementDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                // takes current directory
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<FamilyManagementDbContext>();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            return new FamilyManagementDbContext(optionsBuilder.Options);
        }
    }

}
