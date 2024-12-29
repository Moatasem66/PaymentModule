using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaymentModule.Context;
using PaymentModule.Entities;
using PaymentModule.Contracts;
using PaymentModule.DTOs.PaymentDTO;
using PaymentModule.DTOs.PaymentHistoryDTO;
namespace PaymentModule.Services;
/// <summary>
/// Service class responsible for managing discounts.
/// </summary>
public class PaymentHistoryService : IPaymentHistoryService
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public PaymentHistoryService(IMapper mapper, AppDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<PaymentHistoryResponseDTO?> GetPaymentHistoryByIdAsync(int id)
    {
        var Response = await _context.PaymentHistories
                                                    .Include(x => x.Payment)
                                                    .ThenInclude(i => i!.Invoice)
                                                    .ThenInclude(d => d!.Discount)
                                                    .FirstOrDefaultAsync(x => x.Id == id);

        return Response == null ? null : _mapper.Map<PaymentHistoryResponseDTO>(Response);
    }
    /// <inheritdoc/>
    public async Task<List<PaymentHistoryResponseDTO>?> GetPaymentHistoryByPaymentIdAsync(int paymentId)
    {
        var PaymentHistoryCollection = await _context.PaymentHistories.Where( p => p.PaymentId == paymentId).ToListAsync();

        return PaymentHistoryCollection == null ? null : _mapper.Map<List<PaymentHistoryResponseDTO>>(PaymentHistoryCollection);
    }
    /// <inheritdoc/>
    public async Task<List<PaymentHistoryResponseDTO>> GetAllPaymentHistoriesAsync()
    {
        var ResponseLst = await _context.PaymentHistories.Include(x=>x.Payment).ToListAsync();

        return _mapper.Map<List<PaymentHistoryResponseDTO>>(ResponseLst);
    }
    /// <inheritdoc/>
    public async Task<PaymentHistoryResponseDTO> CreatePaymentHistoryAsync(PaymentHistoryRequestDTO paymentHistoryRequest)
    {
        try
        {
            var PaymentHistory = _mapper.Map<PaymentHistory>(paymentHistoryRequest);

            await _context.PaymentHistories.AddAsync(PaymentHistory);
            await _context.SaveChangesAsync();

            return _mapper.Map<PaymentHistoryResponseDTO>(PaymentHistory);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
  
   
}
