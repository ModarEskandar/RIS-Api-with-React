using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Data.DataSeed;

namespace Data.Models;

public partial class RISDbContext : IdentityDbContext<ApiUser>
{
    public RISDbContext()
    {
    }

    public RISDbContext(DbContextOptions<RISDbContext> options)
        : base(options)
    {

    }
    public DbSet<Patient> patients { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        dbContextOptionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServerCS"))
        .EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RolesConfiguration())
        //.ApplyConfiguration(new PatientsConfiguration());
        .ApplyConfiguration(new RadOrdersConfiguration());

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Patient>()
                .HasMany(p => p.Orders)
                .WithOne(m => m.patient)
                .HasForeignKey(m => m.PatientId)
                .OnDelete(DeleteBehavior.Cascade);


    }



}