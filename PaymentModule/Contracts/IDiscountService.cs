using PaymentModule.DTOs.DiscountDTO;

namespace PaymentModule.Contracts;

public interface IDiscountService
{
    /// <summary>
    /// method to get Discount by Id if not found return null 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns>DiscountResponseDTO</returns>
    Task<DiscountResponseDTO?> GetDiscountByIdAsync(int id);
    /// <summary>
    /// method to get all Discounts 
    /// </summary>
    /// <returns> List of Discounts response </returns>
    Task<List<DiscountResponseDTO>> GetAllDiscountsAsync();
    /// <summary>
    /// method to create Discount 
    /// </summary>
    /// <param name="DiscountRequest"></param>
    /// <returns>DiscountResponseDTO</returns>
    Task<DiscountResponseDTO> CreateDiscountAsync(DiscountRequestDTO discountRequest);
    /// <summary>
    /// mehtod to update Discount if not found Discount to update by this id  return false 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="DiscountRequest"></param>
    /// <returns>bool</returns>
    Task<bool> UpdateDiscountAsync(int id, DiscountRequestDTO discountRequest);
    /// <summary>
    /// mehtod to delete Discount if not found Discount to delete by this id  return false 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns>bool</returns>
    Task<bool> DeleteDiscountAsync(int id);
}
