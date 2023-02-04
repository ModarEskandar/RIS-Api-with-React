using System.Configuration;
using Microsoft.EntityFrameworkCore;
namespace Data.Models;

public partial class RISDbContext : DbContext
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
        dbContextOptionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServerCS"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>()
                .HasMany(p => p.Orders)
                .WithOne(m => m.patient)
                .HasForeignKey(m => m.PatientId)
                .OnDelete(DeleteBehavior.Cascade);
        Patient[] patientsToSeed = new Patient[5];
        RadOrder[] radOrdersToSeed = new RadOrder[10];

        for (int i = 1; i <= 5; i++)
        {
            patientsToSeed[i - 1] = new Patient
            {
                Id = i,
                Firstname = $"patient{i}",
                Lastname = $"father{i}",
                Givenid = $"{i}{i}{i}{i}{i}",
                Nationalidnumber = "11111111111",


            };
        }

        modelBuilder.Entity<Patient>().HasData(patientsToSeed);
    }



}