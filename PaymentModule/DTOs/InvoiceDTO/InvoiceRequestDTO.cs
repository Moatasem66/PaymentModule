using System.ComponentModel.DataAnnotations;

namespace PaymentModule.DTOs.InvoiceDTO;

public class InvoiceRequestDTO
{
    public DateOnly Date { get; set; }
    [Required]
    public string Status { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public decimal FinalAmount { get; set; }
    public int PatiantId { get; set; }
}
