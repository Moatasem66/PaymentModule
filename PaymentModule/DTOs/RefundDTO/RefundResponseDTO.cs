using PaymentModule.DTOs.InvoiceDTO;

namespace PaymentModule.DTOs.RefundDTO;

public class RefundResponseDTO
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public string Reason { get; set; }
    public string Status { get; set; }
    public int ProcessedBy { get; set; }
    public string PaymentMethod { get; set; }
    public InvoiceResponseDTO? InvoiceResponse { get; set; }
}
