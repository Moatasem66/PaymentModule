using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentModule.Entities;

namespace PaymentModule.Configurations;
/// <summary>
/// Configuraion For Entity Refund
/// </summary>
public class RefundConfiguration : IEntityTypeConfiguration<Refund>
{
    public void Configure(EntityTypeBuilder<Refund> builder)
    {
        /// <summary>
        /// This ensures that the column will store up to 10 digits in total, with 2 digits after the decimal point.
        ///</ summary>
        builder
            .Property(x => x.Amount)
            .HasColumnType("decimal(10,2)");


        /// <summary>
        /// The relationship is a one-to-many from Refund to Invoice.
        /// Cannot delete discount restrict on Delete Behavior 
        /// </summary>
        builder
            .HasOne(x => x.Invoice)
            .WithMany(x => x.Refunds)
            .HasForeignKey(x => x.InvoiceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
