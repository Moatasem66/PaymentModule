using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentModule.Entities;

namespace PaymentModule.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder
         .Property(i => i.AmountPaid)
         .HasColumnType("decimal(9,3)");

        builder
            .HasOne(i => i.Invoice)
            .WithMany(p => p.Payments)
            .HasForeignKey(i => i.InvoiceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
