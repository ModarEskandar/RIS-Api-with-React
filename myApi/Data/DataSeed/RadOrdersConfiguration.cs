using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.DataSeed
{
    public class RadOrdersConfiguration : IEntityTypeConfiguration<RadOrder>
    {
        public void Configure(EntityTypeBuilder<RadOrder> builder)
        {
            RadOrder[] radOrdersToSeed = new RadOrder[5];

            for (int i = 1; i <= 5; i++)
            {
                radOrdersToSeed[i - 1] = new RadOrder
                {
                    Id = i,
                    PatientId = i
                };
            }
            builder.HasData(
               radOrdersToSeed
            );
        }
    }
}