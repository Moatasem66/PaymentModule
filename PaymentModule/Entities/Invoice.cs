namespace PaymentModule.Entities;
/// <summary>
///  entity for Invoice .
/// Contain  properties Id , Date , Status , TotalAmount , FinalAmount , PatiantId. 
/// FinalAmount = TotalAmount -  TotalAmount * Presentage From Discount.
/// relation one to Many from discount to invoice 
/// relation Many to One from invoice to Payment  
/// relation Many to One from invoice to Invoice Details   
/// </summary>
public class Invoice
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; } 
    public string Status { get; set; } 
    public decimal TotalAmount { get; set; }
    public decimal FinalAmount { get; set; }
    public int PatientId { get; set; }
    public int? DiscountId { get; set; }
    public virtual Discount? Discount { get; set; }
    public virtual ICollection<Payment>? Payments { get;set; }
    public virtual ICollection<InvoiceDetail>? InvoiceDetails { get;set; }
}
