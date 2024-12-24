using PaymentModule.DTOs.PaymentDTO;
using PaymentModule.DTOs.PaymentHistoryDTO;

namespace PaymentModule.Contracts;

public interface IPaymentHistoryService
{
    /// <summary>
    /// method to get PaymentHistory by Id if not found return null 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns>PaymentHistoryResponseDTO</returns>
    Task<PaymentHistoryResponseDTO?> GetPaymentHistoryByIdAsync(int id);
    /// <summary>
    /// method to get all PaymentHistorys by PaymentId
    /// </summary>
    /// <param name="paymentId"></param>
    /// <returns>List of PaymentHistorys response </returns>
    Task<List<PaymentHistoryResponseDTO>?> GetPaymentHistoryByPaymentIdAsync(int paymentId);
    /// <summary>
    /// method to get all PaymentHistorys 
    /// </summary>
    /// <returns>List of PaymentHistorys response </returns>
    Task<List<PaymentHistoryResponseDTO>> GetAllPaymentHistoriesAsync();
    /// <summary>
    /// method to create PaymentHistory 
    /// </summary>
    /// <param name="PaymentHistoryRequest"></param>
    /// <returns>PaymentHistoryResponseDTO</returns>
    Task<PaymentHistoryResponseDTO> CreatePaymentHistoryAsync(PaymentHistoryRequestDTO paymentHistoryRequest);
 
}
