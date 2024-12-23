using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentModule.Entities;

namespace PaymentModule.Configurations;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder
         .Property(i => i.Presentage)
         .HasColumnType("decimal(5,3)");
    }
}
