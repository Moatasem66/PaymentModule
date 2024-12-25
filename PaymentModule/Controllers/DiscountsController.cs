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
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getdiscountbyid/{id}")]
    public async Task<IActionResult> GetDiscountById(int id)
    {
        var Response = await _discountService.GetDiscountByIdAsync(id);
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
    public async Task<IActionResult> CreateDiscountAsync(DiscountRequestDTO discountRequest)
    {
        var Response = await _discountService.CreateDiscountAsync(discountRequest);

        return Response == null ? BadRequest() : Ok(Response);
    }
    /// <summary>
    /// Action Method to update Discount if not found entity for the id return NotFound
    /// </summary>
    /// <param name="id"></param>
    /// <param name="discountRequest"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("updatediscount/{id}")]
    public async Task<IActionResult> UpdateDiscountAsync(int id, DiscountRequestDTO discountRequest)
    {
        if(!ModelState.IsValid)
            return NotFound();
        var IsUpdated = await _discountService.UpdateDiscountAsync(id, discountRequest);

        return IsUpdated ? NoContent() : NotFound();
    }
    /// <summary>
    /// Action Method To Delete Discount by id if not found entity for the id return NotFound
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete]
    [Route("deleteediscount/{id}")]
    public async Task<IActionResult> DeleteDiscountAsync(int id)
    {
        var IsDeleted = await _discountService.DeleteDiscountAsync(id);

        return IsDeleted ? NoContent() : NotFound();
    }
}
