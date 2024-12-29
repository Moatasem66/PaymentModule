using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaymentModule.Context;
using PaymentModule.DTOs.RefundDTO;
using PaymentModule.Entities;
using PaymentModule.Contracts;
namespace PaymentModule.Services;
/// <summary>
/// Refund Service to handle all methods related to Refund Entity 
/// </summary>
/// <param name="mapper"></param>
/// <param name="context"></param>
public class RefundService(IMapper mapper, AppDbContext context) : IRefundService
{
    private readonly IMapper _mapper = mapper;
    private readonly AppDbContext _context = context;

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

            var CurrentInvoice = await _context.Invoices.FindAsync(refundRequest.InvoiceId);

            if (CurrentInvoice != null)
            {
                await _context.Refunds.AddAsync(Refund);
                await _context.SaveChangesAsync();
                CurrentInvoice.TotalAmount -= refundRequest.Amount;
            }



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

            var CurrentInvoice = await _context.Invoices.FindAsync(CurrentRefund.InvoiceId);
            if (CurrentInvoice != null)
                CurrentInvoice.TotalAmount += CurrentRefund.Amount;

            var UpdatedInvoice = await _context.Invoices.FindAsync(refundRequest.InvoiceId);
            if (UpdatedInvoice != null)
                UpdatedInvoice.TotalAmount -= refundRequest.Amount;

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

            var CurrentInvoice = await _context.Invoices.FindAsync(CurrentRefund.InvoiceId);
            if (CurrentInvoice != null)
                CurrentInvoice.TotalAmount += CurrentRefund.Amount;

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
