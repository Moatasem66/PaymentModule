using Microsoft.AspNetCore.Mvc;
using PaymentModule.Contracts;
using PaymentModule.DTOs.RefundDTO;
namespace PaymentModule.Controllers;

[Route("api/[controller]")]
[ApiController]

/// <summary>
/// Conroller to handle httprequest for Refund  
/// </summary>
public class RefundsController : ControllerBase
{
    private readonly IRefundService _RefundService ;

    public RefundsController(IRefundService RefundService)
    {
        _RefundService = RefundService;
    }

    /// <summary>
    /// action method to get Refund by id if not found return bad request 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getRefundbyid/{id}")]
    public async Task<IActionResult> GetRefundById(int id)
    {
        var Response = await _RefundService.GetRefundByIdAsync(id);
        return Response == null ? BadRequest() : Ok(Response);
    }
    /// <summary>
    /// action method to get list of Refunds if count of list equal 0 return bad request 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("getallrefunds")]
    public async Task<IActionResult> GetAllRefundsAsync()
    {
        var ResponseList = await _RefundService.GetAllRefundsAsync();

        return ResponseList.Count == 0 ? BadRequest() : Ok(ResponseList);
    }
    /// <summary>
    /// action method to create Refund if find error return bad request
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("createrefund")]
    public async Task<IActionResult> CreateRefundAsync(RefundRequestDTO refundRequest)
    {
        var Response = await _RefundService.CreateRefundAsync(refundRequest);

        return Response == null ? BadRequest() : Ok(Response);
    }
    /// <summary>
    /// Action Method to update Refund if not found entity for the id return NotFound
    /// </summary>
    /// <param name="id"></param>
    /// <param name="RefundRequest"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("updaterefund/{id}")]
    public async Task<IActionResult> UpdateRefundAsync(int id, RefundRequestDTO refundRequest)
    {
        if(!ModelState.IsValid)
            return NotFound();
        var IsUpdated = await _RefundService.UpdateRefundAsync(id, refundRequest);

        return IsUpdated ? NoContent() : NotFound();
    }
    /// <summary>
    /// Action Method To Delete Refund by id if not found entity for the id return NotFound
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete]
    [Route("deleteerefund/{id}")]
    public async Task<IActionResult> DeleteRefundAsync(int id)
    {
        var IsDeleted = await _RefundService.DeleteRefundAsync(id);

        return IsDeleted ? NoContent() : NotFound();
    }
}
