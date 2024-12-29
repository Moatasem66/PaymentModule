using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentModule.Contracts;
using PaymentModule.DTOs.InvoiceDTO;

namespace PaymentModule.Controllers;
[Route("api/[controller]")]
[ApiController]

/// <summary>
/// Conroller to handle httprequest for Invoice  
/// </summary>
public class InvoicesController(IInvoiceService invoiceService) : ControllerBase
{
    private readonly IInvoiceService _invoiceService = invoiceService;
    /// <summary>
    /// action method to get invoice by id if not found return bad request 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getinvoicebyid/{id}")]
    public async Task<IActionResult> GetInvoiceById(int id)
    {
        var Response = await _invoiceService.GetInvoiceByIdAsync(id);
        return Response == null ? NotFound() : Ok(Response);
    }
    /// <summary>
    /// action method to get invoice by id if not found return bad request 
    /// </summary>
    /// <param name="discountId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getinvoicebydiscountid/{discountId}")]
    public async Task<IActionResult> GetInvoiceByDiscountIdId(int discountId)
    {
        var Response = await _invoiceService.GetInvoiceByDiscountIdAsync(discountId);
        return Response == null ? BadRequest() : Ok(Response);
    }
    /// <summary>
    /// action method to get list of invoices if count of list equal 0 return bad request 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("getallinvoices")]
    public async Task<IActionResult> GetAllInvoicesAsync()
    {
        var ResponseList = await _invoiceService.GetAllInvoicesAsync();

        return ResponseList.Count == 0 ? BadRequest() :Ok(ResponseList);
    }
    /// <summary>
    /// action method to create invoice if find error return bad request
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("createinvoice")]
    public async Task<IActionResult> CreateInvoiceAsync (InvoiceRequestDTO invoiceRequest)
    {
        var Response = await _invoiceService.CreateInvoiceAsync(invoiceRequest);

        return Response == null ?  BadRequest() : Ok(Response);
    }
    /// <summary>
    /// Action Method to update invoice if not found entity for the id return false bad request 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("updateinvoice/{id}")]
    public async Task<IActionResult> UpdateInvoiceAsync ( int id , InvoiceRequestDTO invoiceRequest)
    {
        var IsUpdated = await _invoiceService.UpdateInvoiceAsync(id, invoiceRequest);

        return IsUpdated ? NoContent() : NotFound();
    }
    /// <summary>
    /// Action Method To Delete Invoice by id 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("deleteeinvoice/{id}")]
    public async Task<IActionResult> DeleteInvoiceAsync(int id)
    {
        var IsDeleted = await _invoiceService.DeleteInvoiceAsync(id);

        return IsDeleted ? NoContent() : NotFound();
    }
}
