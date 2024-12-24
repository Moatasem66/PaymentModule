using PaymentModule.DTOs.PaymentDTO;
using PaymentModule.DTOs.PaymentHistoryDTO;

namespace PaymentModule.Contracts;

public interface IPaymentService
{
    /// <summary>
    /// method to get Payment by Id if not found return null 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns>PaymentResponseDTO</returns>
    Task<PaymentResponseDTO?> GetPaymentByIdAsync(int id);
    /// <summary>
    /// method to get all Payments 
    /// </summary>
    /// <returns>List of Payments response </returns>
    Task<List<PaymentResponseDTO>> GetAllPaymentsAsync();
    /// <summary>
    /// method to create Payment 
    /// </summary>
    /// <param name="PaymentRequest"></param>
    /// <returns>PaymentResponseDTO</returns>
    Task<PaymentResponseDTO> CreatePaymentAsync( PaymentRequestDTO paymentRequest);
    /// <summary>
    /// mehtod to update Payment if not found Payment to update by this id  return false 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="PaymentRequest"></param>
    /// <returns>bool</returns>
    Task<bool> UpdatePaymentAsync(int id, PaymentRequestDTO paymentRequest);
    /// <summary>
    /// mehtod to delete Payment if not found Payment to delete by this id  return false 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns>bool</returns>
    Task<bool> DeletePaymentAsync(int id);
}
