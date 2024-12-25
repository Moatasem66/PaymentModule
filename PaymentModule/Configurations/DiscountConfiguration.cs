using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentModule.Entities;

namespace PaymentModule.Configurations;
/// <summary>
/// Configuration to Discount Entity 
/// </summary>
public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        /// <summary>
        /// This ensures that the column will store up to 5 digits in total, with 3 digits after the decimal point.
        ///</ summary
        builder
         .Property(i => i.Presentage)
         .HasColumnType("decimal(5,3)");
    }
}
