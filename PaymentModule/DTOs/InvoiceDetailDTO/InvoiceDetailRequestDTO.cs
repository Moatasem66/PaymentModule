namespace PaymentModule.DTOs.InvoiceDetailDTO;

public class InvoiceDetailRequestDTO
{
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
