using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentModule.Entities;
using System.Reflection.Emit;
namespace PaymentModule.Configurations;
public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder
           .Property(i => i.TotalAmount)
           .HasColumnType("decimal(10,2)");
           
        builder
          .Property(i => i.FinalAmount)
          .HasColumnType("decimal(10,2)");
    }
}
