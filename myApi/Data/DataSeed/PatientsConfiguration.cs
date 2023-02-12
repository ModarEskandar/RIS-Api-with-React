using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.DataSeed
{
    public class PatientsConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            Patient[] patientsToSeed = new Patient[5];

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
            builder.HasData(
               patientsToSeed
            );
        }
    }
}