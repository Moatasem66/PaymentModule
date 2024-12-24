namespace PaymentModule.Entities;
/// <summary>
/// this entity for Invoice to Patiant.
/// Contain  properties Id , Date , Status , TotalAmount , FinalAmount , PatiantId. 
/// FinalAmount = TotalAmount -  TotalAmount * PresentageFrom Discount.
/// </summary>
public class Invoice
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public string Status { get; set; } 
    public decimal TotalAmount { get; set; }
    public decimal FinalAmount { get; set; }
    public int PatientId { get; set; }
    public int DiscountId { get; set; }
    public virtual Discount? Discount { get; set; }
    public virtual ICollection<Payment>? Payments { get;set; }
}
