using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentModule.Entities;

namespace PaymentModule.Configurations;
/// <summary>
/// Configuration To PaymentHistory Entity 
/// </summary>
public class PaymentHistoryConfiguration : IEntityTypeConfiguration<PaymentHistory>
{
    public void Configure(EntityTypeBuilder<PaymentHistory> builder)
    {

        /// <summary>
        /// relationship one to many from paymenthistory to payment 
        /// delete behavior cannont delete from this relationship 
        /// </summary>
        builder
            .HasOne(i => i.Payment)
            .WithMany(p => p.PaymentHistories)
            .HasForeignKey(i => i.PaymentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
