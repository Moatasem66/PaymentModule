using System.ComponentModel.DataAnnotations;

namespace PaymentModule.DTOs.PaymentDTO;

/// <summary>
/// Represents a request for recording a payment, including details about 
/// the payment date, amount, method, and associated invoice.
/// </summary>
public class PaymentRequestDTO
{
   
    [Required(ErrorMessage = "Payment date is required.")]
    public DateTime Date { get; set; } 

    [Required(ErrorMessage = "Amount paid is required.")]
    [Range(1, double.MaxValue, ErrorMessage = "AmountPaid must be greater than 0.")]
    public decimal AmountPaid { get; set; }

    [Required(ErrorMessage = "Payment method is required.")]
    public string PaymentMethod { get; set; } 
    
    [Required(ErrorMessage = "Invoice ID is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "InvoiceId must be greater than 0.")]
    public int InvoiceId { get; set; }
}