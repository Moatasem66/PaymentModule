using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentModule.Entities;
using System.Reflection.Emit;
namespace PaymentModule.Configurations;

/// <summary>
/// Configuration to Invoice Entity 
/// </summary>
public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        /// <summary>The default value is set to the current date and time (DateTime.Now) when a new entity is created.
        ///</ summary>
        builder
            .Property(x => x.CreatedOn)
            .HasDefaultValue(DateTime.Now);
        /// <summary>
        /// This ensures that the column will store up to 10 digits in total, with 2 digits after the decimal point.
        ///</ summary>
        builder
           .Property(i => i.TotalAmount)
           .HasColumnType("decimal(10,2)");
           
        builder
          .Property(i => i.FinalAmount)
          .HasColumnType("decimal(10,2)");
        /// <summary>
        /// The relationship is a one-to-many from Discount to Invoice.
        /// Cannot delete discount restrict on Delete Behavior 
        /// </summary>
        builder
            .HasOne(x => x.Discount)
            .WithMany(i => i.Invoices)
            .HasForeignKey(d => d.DiscountId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
