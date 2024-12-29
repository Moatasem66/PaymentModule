using System.ComponentModel.DataAnnotations;

namespace PaymentModule.DTOs.RefundDTO;
/// <summary>
/// DTO for creating a refund request for refund.
/// </summary>
public class RefundRequestDTO
{
    [Required(ErrorMessage = "Amount is Required")]
    [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Date is required.")]
    public DateTime Date { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "Reason is required.")]
    [StringLength(500, ErrorMessage = "Reason cannot exceed 500 characters.")]
    public string Reason { get; set; }

    [Required(ErrorMessage = "Status is required.")]
    [RegularExpression("^(Pending|Approved|Rejected)$", ErrorMessage = "Status must be either Pending, Approved, or Rejected.")]
    public string Status { get; set; }

    [Required(ErrorMessage = "ProcessedBy is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "ProcessedBy must be a valid user ID.")]
    public int ProcessedBy { get; set; }

    [Required(ErrorMessage = "PaymentMethod is required.")]
    [StringLength(50, ErrorMessage = "PaymentMethod cannot exceed 50 characters.")]
    public string PaymentMethod { get; set; }

    [Required(ErrorMessage = "InvoiceId is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "InvoiceId must be a valid ID.")]
    public int InvoiceId { get; set; }
}

