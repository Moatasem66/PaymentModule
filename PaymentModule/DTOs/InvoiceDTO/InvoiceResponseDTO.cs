using PaymentModule.DTOs.DiscountDTO;
using PaymentModule.DTOs.InvoiceDetailDTO;

namespace PaymentModule.DTOs.InvoiceDTO;

public class InvoiceResponseDTO
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public string Status { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public decimal FinalAmount { get; set; }
    public int PatientId { get; set; }
    public int DiscountId { get; set; }
    public virtual DiscountResponseDTO? Discount {get; set;}
    public virtual List<InvoiceDetailResponseDTO> InvoiceDetails { get; set; }
}
