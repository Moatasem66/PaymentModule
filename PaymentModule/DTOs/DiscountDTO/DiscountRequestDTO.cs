using System.ComponentModel.DataAnnotations;

namespace PaymentModule.DTOs.DiscountDTO;
/// <summary>
/// requestDTO to Discount Entity to create or update 
/// </summary>
public class DiscountRequestDTO
{
    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Percentage is required.")]
    [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100.")]
    public decimal Percentage { get; set; }

    [Required(ErrorMessage = "Percentage is required.")]
    public string Condation { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Insurance ID must be greater than 0.")]
    public int? InsurenceId { get; set; }
}
