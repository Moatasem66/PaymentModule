using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentModule.Entities;
using System.Reflection.Emit;
namespace PaymentModule.Configurations;
public class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
{
    public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
    {
        /// <summary>
        ///This ensures that the column will store up to 10 digits in total, with 2 digits after the decimal point.
        ///</ summary>
        
        builder
           .Property(i => i.UnitPrice)
           .HasColumnType("decimal(10,2)");
           
        builder
          .Property(i => i.TotalPrice)
          .HasColumnType("decimal(10,2)");

        /// <summary>
        /// The relationship is a one-to-many from Invoice to InvoiceDetails.
        /// </summary>
        builder
            .HasOne(x => x.Invoice)
            .WithMany(i => i.InvoiceDetails)
            .HasForeignKey(d => d.InvoiceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
