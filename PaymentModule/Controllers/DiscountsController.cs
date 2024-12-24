using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentModule.Contracts;
using PaymentModule.DTOs.DiscountDTO;
using PaymentModule.Services;

namespace PaymentModule.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DiscountsController : ControllerBase
{
    private readonly IDiscountService _discountService ;

    public DiscountsController(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    /// <summary>
    /// action method to get Discount by id if not found return bad request 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getdiscountbyid/{Id}")]
    public async Task<IActionResult> GetDiscountById(int Id)
    {
        var Response = await _discountService.GetDiscountByIdAsync(Id);
        return Response == null ? BadRequest() : Ok(Response);
    }
    /// <summary>
    /// action method to get list of Discounts if count of list equal 0 return bad request 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("getalldiscounts")]
    public async Task<IActionResult> GetAllDiscountsAsync()
    {
        var ResponseList = await _discountService.GetAllDiscountsAsync();

        return ResponseList.Count == 0 ? BadRequest() : Ok(ResponseList);
    }
    /// <summary>
    /// action method to create Discount if find error return bad request
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("creatediscount")]
    public async Task<IActionResult> CreateDiscountAsync(DiscountRequestDTO request)
    {
        var Response = await _discountService.CreateDiscountAsync(request);

        return Response == null ? BadRequest() : Ok(Response);
    }
    /// <summary>
    /// Action Method to update Discount if not found entity for the id return false bad request 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("updatediscount/{Id}")]
    public async Task<IActionResult> UpdateDiscountAsync(int Id, DiscountRequestDTO Request)
    {
        var IsUpdated = await _discountService.UpdateDiscountAsync(Id, Request);

        return IsUpdated ? NoContent() : NotFound();
    }
    /// <summary>
    /// Action Method To Delete Discount by id 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("deleteediscount/{Id}")]
    public async Task<IActionResult> DeleteDiscountAsync(int Id)
    {
        var IsDeleted = await _discountService.DeleteDiscountAsync(Id);

        return IsDeleted ? NoContent() : NotFound();
    }
}
