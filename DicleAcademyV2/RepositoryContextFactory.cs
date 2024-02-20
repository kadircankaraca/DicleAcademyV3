using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Repositories.EF_Core;

namespace DicleAcademyV2
{
    public class RepositoryContextFactory
    {
        public RepositoryContext CreateDbContext(string[] args)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var builder = new DbContextOptionsBuilder<RepositoryContext>()
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    prj => prj.MigrationsAssembly("DicleAcademyV2"));

                return new RepositoryContext(builder.Options);
            }
        }
}
