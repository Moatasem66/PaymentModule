using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaymentModule.Context;
using PaymentModule.Entities;
using PaymentModule.Contracts;
using PaymentModule.DTOs.PaymentDTO;
using PaymentModule.DTOs.InvoiceDTO;
namespace PaymentModule.Services;

public class PaymentService : IPaymentService
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public PaymentService(IMapper mapper, AppDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<PaymentResponseDTO?> GetPaymentByIdAsync(int id)
    {
        var Response = await _context.Payments.Include(x => x.Invoice).FirstOrDefaultAsync(x => x.Id == id);
       
        return Response == null ? null : _mapper.Map<PaymentResponseDTO>(Response);
    }
    /// <inheritdoc/>
    public async Task<List<PaymentResponseDTO>?> GetPaymentByInvoiceIdAsync(int invoiceId)
    {
        var PaymentCollection = await _context.Payments.Where(x => x.InvoiceId == invoiceId).ToListAsync() ;

        return PaymentCollection == null ? null : _mapper.Map<List<PaymentResponseDTO>?>(PaymentCollection);
        
    }
    /// <inheritdoc/>
    public async Task<List<PaymentResponseDTO>> GetAllPaymentsAsync()
    {
        var ResponseLst = await _context.Payments.Include(x=>x.Invoice).ToListAsync();

        return _mapper.Map<List<PaymentResponseDTO>>(ResponseLst);
    }
    /// <inheritdoc/>
    public async Task<PaymentResponseDTO> CreatePaymentAsync(PaymentRequestDTO paymentRequest)
    {
        try
        {
            var Payment = _mapper.Map<Payment>(paymentRequest);

            await _context.Payments.AddAsync(Payment);
            await _context.SaveChangesAsync();

            return _mapper.Map<PaymentResponseDTO>(Payment);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    /// <inheritdoc/>
    public async Task<bool> UpdatePaymentAsync(int id, PaymentRequestDTO paymentRequest)
    {
        try
        {
            var CurrentPayment = await _context.Payments.FindAsync(id);
            if (CurrentPayment == null)
                return false;
            _mapper.Map(paymentRequest, CurrentPayment);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    /// <inheritdoc/>
    public async Task<bool> DeletePaymentAsync(int id)
    {
        try
        {
            var CurrentPayment = await _context.Payments.FindAsync(id);
            if (CurrentPayment == null)
                return false;
            _context.Payments.Remove(CurrentPayment);
            _context.SaveChanges();
            return true;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
