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
/// Conroller to handle httprequest for Payment History  
/// </summary>
public class PaymentHistoriesController : ControllerBase
{
    private readonly IPaymentHistoryService _paymentHistoryService ;

    public PaymentHistoriesController(IPaymentHistoryService paymentHistoryService)
    {
        _paymentHistoryService = paymentHistoryService;
    }

    /// <summary>
    /// action method to get Payment by id if not found return bad request 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getpaymenthistorybyid/{id}")]
    public async Task<IActionResult> GetPaymentHistoryByIdAsync(int id)
    {
        var Response = await _paymentHistoryService.GetPaymentHistoryByIdAsync(id);
        return Response == null ? BadRequest() : Ok(Response);
    }
    /// <summary>
    /// action method to get Payment history by payment id if not found return bad request 
    /// </summary>
    /// <param name="paymentId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getpaymenthistorybypaymentid/{paymentId}")]
    public async Task<IActionResult> GetPaymentHistoryBypaymentIdAsync(int paymentId)
    {
        var Response = await _paymentHistoryService.GetPaymentHistoryByPaymentIdAsync(paymentId);
        return Response == null ? BadRequest() : Ok(Response);
    }
    /// <summary>
    /// action method to get list of Payments if count of list equal 0 return bad request 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("getallpaymenthistories")]
    public async Task<IActionResult> GetAllPaymentsAsync()
    {
        var ResponseList = await _paymentHistoryService.GetAllPaymentHistoriesAsync();

        return ResponseList.Count == 0 ? BadRequest() : Ok(ResponseList);
    }
    /// <summary>
    /// action method to create Payment if find error return bad request
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("createpaymenthistory")]
    public async Task<IActionResult> CreatePaymentAsync(PaymentHistoryRequestDTO paymetHistoryRequest)
    {
        var Response = await _paymentHistoryService.CreatePaymentHistoryAsync(paymetHistoryRequest);

        return Response == null ? BadRequest() : Ok(Response);
    }
   
  
}
