namespace PaymentModule.DTOs.PaymentDTO;

public class PaymentRequestDTO
{
    public DateOnly Date { get; set; }
    public decimal AmountPaid { get; set; }
    public string PaymentMethod { get; set; }
    public int InvoiceId { get; set; }
}
