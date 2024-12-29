using AutoMapper;
using PaymentModule.Context;
using PaymentModule.Entities;
using PaymentModule.Contracts;
using PaymentModule.DTOs.DiscountDTO;
using Microsoft.EntityFrameworkCore;

namespace PaymentModule.Services;
/// <summary>
/// Service class responsible for managing discounts.
/// </summary>
public class DiscountService : IDiscountService
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public DiscountService(IMapper mapper, AppDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<DiscountResponseDTO?> GetDiscountByIdAsync(int id)
    {
        var Response = await _context.Discounts.FindAsync(id);
        return Response == null ? null : _mapper.Map<DiscountResponseDTO>(Response);
    }
    /// <inheritdoc/>
    public async Task<List<DiscountResponseDTO>> GetAllDiscountsAsync()
    {
        var ResponseLst = await _context.Discounts.ToListAsync();

        return _mapper.Map<List<DiscountResponseDTO>>(ResponseLst);
    }
    /// <inheritdoc/>
    public async Task<DiscountResponseDTO> CreateDiscountAsync(DiscountRequestDTO discountRequest)
    {
        try
        {
            var Discount = _mapper.Map<Discount>(discountRequest);

            await _context.Discounts.AddAsync(Discount);
            await _context.SaveChangesAsync();

            return _mapper.Map<DiscountResponseDTO>(Discount);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    /// <inheritdoc/>
    public async Task<bool> UpdateDiscountAsync(int id, DiscountRequestDTO discountRequest)
    {
        try
        {
            var CurrentDiscount = await _context.Discounts.FindAsync(id);
            if (CurrentDiscount == null)
                return false;
            _mapper.Map(discountRequest, CurrentDiscount);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    /// <inheritdoc/>
    public async Task<bool> DeleteDiscountAsync(int id)
    {
        try
        {
            var CurrentDiscount = await _context.Discounts.FindAsync(id);
            if (CurrentDiscount == null)
                return false;
            _context.Discounts.Remove(CurrentDiscount);
            _context.SaveChanges();
            return true;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}
