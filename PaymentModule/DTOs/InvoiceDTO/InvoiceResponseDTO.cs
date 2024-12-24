using PaymentModule.DTOs.DiscountDTO;

namespace PaymentModule.DTOs.InvoiceDTO;

public class InvoiceResponseDTO
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public string Status { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public decimal FinalAmount { get; set; }
    public int PatientId { get; set; }
    public int DiscountId { get; set; }
    public virtual DiscountResponseDTO? Discount {get; set;}
}
