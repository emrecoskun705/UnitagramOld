using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Unitagram.Core.Identity;
using Unitagram.Core.Entities;
using Unitagram.Core.SeedData;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Unitagram.Infrastructure.DatabaseContext
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
  {
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected ApplicationDbContext()
    {
    }

    public virtual DbSet<University> University { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      CreateUniversitySeedData(builder);
    }

    private void CreateUniversitySeedData(ModelBuilder builder)
    {
      // Read JSON data from province_domains.json
      string jsonFilePath = "province_domains.json";
      string jsonData = File.ReadAllText(jsonFilePath);
      List<UniversitySeedDataModel> seedData = JsonConvert.DeserializeObject<List<UniversitySeedDataModel>>(jsonData);
      int i = 1;
      foreach (var item in seedData)
      {
        builder.Entity<University>().HasData(
            new University
            {
              Id = i++,
              Province = item.Province,
              Name = item.Name,
              Domain = item.Domain,
              Inserted = DateTime.Now,
              LastUpdated = DateTime.Now,
            }
        );
      }
    }
     
  }
}
