namespace PaymentModule.Entities;
/// <summary>
/// Entity for InvoiceDetail  .
/// Contain  properties Id , Description , Quantity , UnitPrice , TotalPrice. 
/// TotalPrice = Quantity *  UnitPrice.
/// relation one to Many from invoiceDetail to invoice 
/// </summary>
public class InvoiceDetail
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public int InvoiceId { get; set; }
    public virtual Invoice? Invoice { get; set; } 
}
