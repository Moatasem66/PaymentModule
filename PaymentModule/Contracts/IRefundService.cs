using PaymentModule.DTOs.RefundDTO;

namespace PaymentModule.Contracts;
/// <summary>
/// Methods related to Refund Enitity 
/// </summary>
public interface IRefundService
{
    /// <summary>
    /// method to get Refund by Id if not found return null 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns>RefundResponseDTO</returns>
    Task<RefundResponseDTO?> GetRefundByIdAsync(int id);
    /// <summary>
    /// method to get all Refunds 
    /// </summary>
    /// <returns>List of Refunds response </returns>
    Task<List<RefundResponseDTO>> GetAllRefundsAsync();
    /// <summary>
    /// method to create Refund 
    /// </summary>
    /// <param name="refundRequest"></param>
    /// <returns>RefundResponseDTO</returns>
    Task<RefundResponseDTO> CreateRefundAsync( RefundRequestDTO refundRequest);
    /// <summary>
    /// mehtod to update Refund if not found Refund to update by this id  return false 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="refundRequest"></param>
    /// <returns>bool</returns>
    Task<bool> UpdateRefundAsync(int id, RefundRequestDTO refundRequest);
    /// <summary>
    /// mehtod to delete Refund if not found Refund to delete by this id  return false 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns>bool</returns>
    Task<bool> DeleteRefundAsync(int id);
}
