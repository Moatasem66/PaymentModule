namespace PaymentModule.Entities;
/// <summary>
/// this entity relative to Invoice to Patiant 
/// Contain Id , Date , Status , TotalAmount , FinalAmount , PatiantId
/// FinalAmount = TotalAmount -  Discount 
/// </summary>
public class Invoice
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public string Status { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public decimal FinalAmount { get; set; }
    public int PatiantId { get; set; }
}
