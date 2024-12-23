using System.ComponentModel.DataAnnotations;

namespace PaymentModule.DTOs.InvoiceDTO;

public class InvoiceRequestDTO
{
    public DateOnly Date { get; set; }
    [Required]
    public string Status { get; set; } = string.Empty;
    [Range(0.01, double.MaxValue)]
    public decimal TotalAmount { get; set; }
    [Range(0.01, double.MaxValue)]
    public decimal FinalAmount { get; set; }
    [Required]
    public int PatientId { get; set; }
}
