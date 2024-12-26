namespace PaymentModule.DTOs.InvoiceDetailDTO;
/// <summary>
/// invoice Response return Id , TotalPrice , Unit Price  , Description  , Quantity 
/// partial in Invoice Response 
/// </summary>
public class InvoiceDetailResponseDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
