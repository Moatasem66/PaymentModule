namespace PaymentModule.Entities;
/// <summary>
/// Entity Refund .
/// Contain properties Id , Amount , Date , Reason , ProcessedBy , PaymentMethod , InvoiceId is forign key 
/// there are relation with Payment One-to-many from Refund to Invoice  
/// </summary>
public class Refund
{
    public int Id { get; set; }               
    public decimal Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;     
    public string Reason { get; set; }       
    public string Status { get; set; }       
    public int ProcessedBy { get; set; }            
    public string PaymentMethod { get; set; }
    public int InvoiceId { get; set; }
    public virtual Invoice? Invoice { get; set; }
}
