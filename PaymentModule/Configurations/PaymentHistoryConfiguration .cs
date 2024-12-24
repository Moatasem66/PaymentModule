using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentModule.Entities;

namespace PaymentModule.Configurations;

public class PaymentHistoryConfiguration : IEntityTypeConfiguration<PaymentHistory>
{
    public void Configure(EntityTypeBuilder<PaymentHistory> builder)
    {
        builder
            .HasOne(i => i.Payment)
            .WithMany(p => p.PaymentHistories)
            .HasForeignKey(i => i.PaymentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
