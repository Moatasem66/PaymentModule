using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentModule.Entities;

namespace PaymentModule.Configurations;
/// <summary>
/// Configuration to Payment Entity 
/// </summary>
public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        /// <summary>
        /// This ensures that the column will store up to 10 digits in total, with 2 digits after the decimal point.
        ///</ summary
        builder
         .Property(i => i.AmountPaid)
         .HasColumnType("decimal(10,3)");


        /// <summary>
        /// relation One to Many from Payment To Invoice 
        /// </summary>
        builder
            .HasOne(i => i.Invoice)
            .WithMany(p => p.Payments)
            .HasForeignKey(i => i.InvoiceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
