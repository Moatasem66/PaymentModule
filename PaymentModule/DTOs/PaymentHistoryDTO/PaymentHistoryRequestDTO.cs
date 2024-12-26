using PaymentModule.Entities;
using System.ComponentModel.DataAnnotations;

namespace PaymentModule.DTOs.PaymentHistoryDTO;

/// <summary>
/// Represents a request to log or retrieve payment history, including 
/// the action date, status, comments, and associated payment ID.
/// </summary>
public class PaymentHistoryRequestDTO
{
  
    [Required(ErrorMessage = "ActionDate is required.")]
    public DateTime ActionDate { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "Status is required.")]
    [StringLength(50, ErrorMessage = "Status cannot exceed 50 characters.")]
    public string Status { get; set; }
    public string? Comment { get; set; }

    [Required(ErrorMessage = "PaymentId is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "PaymentId must be greater than 0.")]
    public int PaymentId { get; set; }
}