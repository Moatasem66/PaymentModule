using PaymentModule.DTOs.InvoiceDetailDTO;
using System.ComponentModel.DataAnnotations;

namespace PaymentModule.DTOs.InvoiceDTO;

public class InvoiceRequestDTO
{
 
    [Required]
    public string Status { get; set; } = string.Empty;
    [Range(1, double.MaxValue, ErrorMessage = "TotalAmount must be greater than 1.")]
    public decimal TotalAmount { get; set; }
    [Range(1, double.MaxValue, ErrorMessage = "FinalAmount must be greater than 1.")]
    public decimal FinalAmount { get; set; }
    [Required]
    public int PatientId { get; set; }
    public int? DiscountId { get; set; }
    public List<InvoiceDetailRequestDTO> InvoiceDetails { get; set; }
}
