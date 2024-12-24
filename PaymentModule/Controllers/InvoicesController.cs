using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentModule.Contracts;
using PaymentModule.DTOs.InvoiceDTO;

namespace PaymentModule.Controllers;
[Route("api/[controller]")]
[ApiController]
/// <summary> Controller to crud operation in invoice entity </summary>
public class InvoicesController(IInvoiceService invoiceService) : ControllerBase
{
    private readonly IInvoiceService _invoiceService = invoiceService;
    /// <summary>
    /// action method to get invoice by id if not found return bad request 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getinvoicebyid/{Id}")]
    public async Task<IActionResult> GetInvoiceById(int Id)
    {
        var Response = await _invoiceService.GetInvoiceByIdAsync(Id);
        return Response == null ? BadRequest() : Ok(Response);
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
    public async Task<IActionResult> CreateInvoiceAsync (InvoiceRequestDTO request )
    {
        var Response = await _invoiceService.CreateInvoiceAsync(request);

        return Response == null ?  BadRequest() : Ok(Response);
    }
    /// <summary>
    /// Action Method to update invoice if not found entity for the id return false bad request 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("updateinvoice/{Id}")]
    public async Task<IActionResult> UpdateInvoiceAsync ( int Id , InvoiceRequestDTO Request)
    {
        var IsUpdated = await _invoiceService.UpdateInvoiceAsync(Id, Request);

        return IsUpdated ? NoContent() : NotFound();
    }
    /// <summary>
    /// Action Method To Delete Invoice by id 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("deleteeinvoice/{Id}")]
    public async Task<IActionResult> DeleteInvoiceAsync(int Id)
    {
        var IsDeleted = await _invoiceService.DeleteInvoiceAsync(Id);

        return IsDeleted ? NoContent() : NotFound();
    }
}
