using PaymentModule.DTOs.InvoiceDTO;
using PaymentModule.Entities;

namespace PaymentModule.DTOs.PaymentDTO;

public class PaymentResponseDTO
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal AmountPaid { get; set; }
    public string PaymentMethod { get; set; }
    public virtual InvoiceResponseDTO? Invoice { get; set; }
}
