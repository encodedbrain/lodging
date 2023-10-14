using lodging.Mappings;
using lodging.Models;
using Microsoft.EntityFrameworkCore;

namespace lodging.Data;

public class LodgingDb : DbContext

{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Reserve> Reserves { get; set; }
    public DbSet<Suite> Suites { get; set; }

    public LodgingDb()
    {
    }


    public LodgingDb(DbContextOptions<LodgingDb> options)
        : base(options)
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configRoot = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //replace appsettings.Development.json with appsettings.json
            .AddJsonFile("appsettings.Development.json")
            .Build();
        optionsBuilder.UseSqlServer(configRoot.GetConnectionString("DefaultConnection"));
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.ApplyConfiguration(new PersonMap());
        modelBuilder.ApplyConfiguration(new ReserveMap());
        modelBuilder.ApplyConfiguration(new SuiteMap());

    }
}
