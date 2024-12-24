using System.ComponentModel.DataAnnotations;

namespace PaymentModule.DTOs.InvoiceDTO;

public class InvoiceRequestDTO
{
    public DateOnly Date { get; set; }
    [Required]
    public string Status { get; set; } = string.Empty;
    [Range(1, double.MaxValue)]
    public decimal TotalAmount { get; set; }
    [Range(1, double.MaxValue)]
    public decimal FinalAmount { get; set; }
    [Required]
    public int PatientId { get; set; }
    public int? DiscountId { get; set; }
}
