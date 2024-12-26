using PaymentModule.DTOs.InvoiceDetailDTO;
using System.ComponentModel.DataAnnotations;

namespace PaymentModule.DTOs.InvoiceDTO;
/// <summary>
/// Represents a request for creating or updating an invoice, 
/// including details about the patient, amounts, discounts, and invoice items.
/// </summary>
public class InvoiceRequestDTO
{
    [Required(ErrorMessage = "Status is required.")]
    public string Status { get; set; } = string.Empty;

    [Range(1, double.MaxValue, ErrorMessage = "TotalAmount required and must be greater than 1.")]
    public decimal TotalAmount { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "FinalAmount required and must be greater than 1.")]
    public decimal FinalAmount { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "PatientId required and must be greater than 0.")]
    public int PatientId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "DiscountId must be greater than 0.")]
    public int? DiscountId { get; set; }

    [MinLength(1, ErrorMessage = "At least one invoice detail is required.")]
    public List<InvoiceDetailRequestDTO> InvoiceDetails { get; set; }
}
