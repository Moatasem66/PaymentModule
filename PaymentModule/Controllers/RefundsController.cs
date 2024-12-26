using Microsoft.AspNetCore.Mvc;
using PaymentModule.Contracts;
using PaymentModule.DTOs.RefundDTO;
namespace PaymentModule.Controllers;

[Route("api/[controller]")]
[ApiController]
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
    [Route("getallRefunds")]
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
    [Route("createRefund")]
    public async Task<IActionResult> CreateRefundAsync(RefundRequestDTO RefundRequest)
    {
        var Response = await _RefundService.CreateRefundAsync(RefundRequest);

        return Response == null ? BadRequest() : Ok(Response);
    }
    /// <summary>
    /// Action Method to update Refund if not found entity for the id return NotFound
    /// </summary>
    /// <param name="id"></param>
    /// <param name="RefundRequest"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("updateRefund/{id}")]
    public async Task<IActionResult> UpdateRefundAsync(int id, RefundRequestDTO RefundRequest)
    {
        if(!ModelState.IsValid)
            return NotFound();
        var IsUpdated = await _RefundService.UpdateRefundAsync(id, RefundRequest);

        return IsUpdated ? NoContent() : NotFound();
    }
    /// <summary>
    /// Action Method To Delete Refund by id if not found entity for the id return NotFound
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete]
    [Route("deleteeRefund/{id}")]
    public async Task<IActionResult> DeleteRefundAsync(int id)
    {
        var IsDeleted = await _RefundService.DeleteRefundAsync(id);

        return IsDeleted ? NoContent() : NotFound();
    }
}
