namespace PaymentModule.Entities;
/// <summary>
/// this entity for Payement to Invoice .
/// Contain  properties Id , Date , AmountPaid , PaymnetMethod 
/// there are relation with invoice One-to-many 
/// </summary>
public class Payment
{
    public int  Id { get; set; }
    public DateOnly Date { get; set; }
    public decimal AmountPaid { get; set; }
    public string PaymentMethod { get; set; }
    public int InvoiceId { get; set; } 
    public virtual Invoice? Invoice { get; set; }
    public virtual ICollection<PaymentHistory>? PaymentHistories { get; set; } 
}
