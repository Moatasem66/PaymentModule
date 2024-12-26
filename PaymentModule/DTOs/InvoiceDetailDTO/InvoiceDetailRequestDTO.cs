using System.ComponentModel.DataAnnotations;

namespace PaymentModule.DTOs.InvoiceDetailDTO;
/// <summary>
/// Dto for Invoice Detail Sent A partial in Invoice Dto 
/// </summary>
public class InvoiceDetailRequestDTO
{
    [Required(ErrorMessage = "Description is required.")]
    [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive integer.")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Unit price is required.")]
    [Range(1, double.MaxValue, ErrorMessage = "Unit price must be greater than zero.")]
    public decimal UnitPrice { get; set; }
}
