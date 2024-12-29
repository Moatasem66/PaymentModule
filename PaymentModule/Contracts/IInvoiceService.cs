using PaymentModule.DTOs.InvoiceDTO;
namespace PaymentModule.Contracts;

public interface IInvoiceService
{
    /// <summary>
    /// method to get Invoice by Id if not found return null 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns>InvoiceResponseDTO</returns>
    Task<InvoiceResponseDTO?> GetInvoiceByIdAsync(int id);
    /// <summary>
    /// method to get Invoice by DiscountId if not found return null 
    /// </summary>
    /// <param name="discountId"></param>
    /// <returns>InvoiceResponseDTO</returns>
    Task<List<InvoiceResponseDTO>?> GetInvoiceByDiscountIdAsync(int discountId);
    /// <summary>
    /// method to get all invoices 
    /// </summary>
    /// <returns>List of invoices response </returns>
    Task<List<InvoiceResponseDTO>> GetAllInvoicesAsync();
    /// <summary>
    /// method to create Invoice 
    /// </summary>
    /// <param name="InvoiceRequest"></param>
    /// <returns>invoiceResponseDTO</returns>
    Task<InvoiceResponseDTO> CreateInvoiceAsync(InvoiceRequestDTO invoiceRequest);
    /// <summary>
    /// mehtod to update Invoice if not found invoice to update by this id  return false 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="InvoiceRequest"></param>
    /// <returns>bool</returns>
    Task<bool> UpdateInvoiceAsync( int id , InvoiceRequestDTO invoiceRequest);
    /// <summary>
    /// mehtod to delete Invoice if not found invoice to delete by this id  return false 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns>bool</returns>
    Task<bool> DeleteInvoiceAsync( int id );
}
