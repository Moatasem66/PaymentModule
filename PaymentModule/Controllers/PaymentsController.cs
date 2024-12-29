using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentModule.Contracts;
using PaymentModule.DTOs.PaymentDTO;
using PaymentModule.DTOs.PaymentHistoryDTO;
using PaymentModule.Services;

namespace PaymentModule.Controllers;
[Route("api/[controller]")]
[ApiController]

/// <summary>
/// Conroller to handle httprequest for Invoice  
/// </summary>
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService ;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    /// <summary>
    /// action method to get Payment by id if not found return bad request 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getPaymentbyid/{id}")]
    public async Task<IActionResult> GetPaymentById(int id)
    {
        var Response = await _paymentService.GetPaymentByIdAsync(id);
        return Response == null ? BadRequest() : Ok(Response);
    }
    /// <summary>
    /// action method to get Payment by Invoice id if not found return bad request 
    /// </summary>
    /// <param name="invoiceId"></param>
    /// <returns>List<PaymentResponse></returns>
    [HttpGet]
    [Route("getpaymentbyinvoiceid")]
    public async Task<IActionResult> GetPaymentByInvoiceId(int invoiceId)
    {
        var Response = await _paymentService.GetPaymentByInvoiceIdAsync(invoiceId);
        return Response == null ? BadRequest() : Ok(Response);
    }
    /// <summary>
    /// action method to get list of Payments if count of list equal 0 return bad request 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("getallpayments")]
    public async Task<IActionResult> GetAllPaymentsAsync()
    {
        var ResponseList = await _paymentService.GetAllPaymentsAsync();

        return ResponseList.Count == 0 ? BadRequest() : Ok(ResponseList);
    }
    /// <summary>
    /// action method to create Payment if find error return bad request
    /// </summary>
    /// <param name="paymentRequest"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("createpayment")]
    public async Task<IActionResult> CreatePaymentAsync(PaymentRequestDTO paymentRequest)
    {
        var Response = await _paymentService.CreatePaymentAsync(paymentRequest);

        return Response == null ? BadRequest() : Ok(Response);
    }
    /// <summary>
    /// Action Method to update Payment if not found entity for the id return false bad request 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="Request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("updatepayment/{id}")]
    public async Task<IActionResult> UpdatePaymentAsync(int id, PaymentRequestDTO paymentRequest)
    {
        var IsUpdated = await _paymentService.UpdatePaymentAsync(id , paymentRequest);

        return IsUpdated ? NoContent() : NotFound();
    }
    /// <summary>
    /// Action Method To Delete Payment by id 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("deleteePayment/{id}")]
    public async Task<IActionResult> DeletePaymentAsync(int id)
    {
        var IsDeleted = await _paymentService.DeletePaymentAsync(id);

        return IsDeleted ? NoContent() : NotFound();
    }
}
