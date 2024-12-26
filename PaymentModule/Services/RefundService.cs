using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaymentModule.Context;
using PaymentModule.DTOs.RefundDTO;
using PaymentModule.Entities;
using PaymentModule.Contracts;

namespace PaymentModule.Services;

public class RefundService : IRefundService
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public RefundService(IMapper mapper, AppDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<RefundResponseDTO?> GetRefundByIdAsync(int id)
    {
        var Response = await _context.Refunds.FindAsync(id);
        return Response == null ? null : _mapper.Map<RefundResponseDTO>(Response);
    }
    /// <inheritdoc/>
    public async Task<List<RefundResponseDTO>> GetAllRefundsAsync()
    {
        var ResponseLst = await _context.Refunds.ToListAsync();

        return _mapper.Map<List<RefundResponseDTO>>(ResponseLst);
    }
    /// <inheritdoc/>
    public async Task<RefundResponseDTO> CreateRefundAsync(RefundRequestDTO refundRequest)
    {
        try
        {
            var Refund = _mapper.Map<Refund>(refundRequest);

            await _context.Refunds.AddAsync(Refund);
            await _context.SaveChangesAsync();

            return _mapper.Map<RefundResponseDTO>(Refund);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    /// <inheritdoc/>
    public async Task<bool> UpdateRefundAsync(int Id, RefundRequestDTO refundRequest)
    {
        try
        {
            var CurrentRefund = await _context.Refunds.FindAsync(Id);
            if (CurrentRefund == null)
                return false;

            _mapper.Map(refundRequest, CurrentRefund);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    /// <inheritdoc/>
    public async Task<bool> DeleteRefundAsync(int id)
    {
        try
        {
            var CurrentRefund = await _context.Refunds.FindAsync(id);
            if (CurrentRefund == null)
                return false;
            _context.Refunds.Remove(CurrentRefund);
            _context.SaveChanges();
            return true;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}
