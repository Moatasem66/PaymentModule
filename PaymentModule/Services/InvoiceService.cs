using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaymentModule.Context;
using PaymentModule.Contracts;
using PaymentModule.DTOs.InvoiceDTO;
using PaymentModule.Entities;

namespace PaymentModule.Services;

public class InvoiceService : IInvoiceService
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public InvoiceService(IMapper mapper , AppDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<InvoiceResponseDTO?> GetInvoiceByIdAsync(int id)
    {
        var Response = await _context.Invoices.Include(d => d.Discount)
                                              .FirstOrDefaultAsync(x => x.Id == id);
        return Response == null ? null : _mapper.Map<InvoiceResponseDTO>(Response);
    }
    /// <inheritdoc/>
    public async Task<List<InvoiceResponseDTO>> GetAllInvoicesAsync()
    {
        var ResponseLst = await _context.Invoices.ToListAsync();

        return _mapper.Map<List<InvoiceResponseDTO>>(ResponseLst);
    }
    /// <inheritdoc/>
    public async Task<InvoiceResponseDTO> CreateInvoiceAsync(InvoiceRequestDTO InvoiceRequest)
    {
        try
        {
            var Invoice = _mapper.Map<Invoice>(InvoiceRequest);

            await _context.Invoices.AddAsync(Invoice);
            await _context.SaveChangesAsync();

            return _mapper.Map<InvoiceResponseDTO>(Invoice);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    /// <inheritdoc/>
    public async Task<bool> UpdateInvoiceAsync(int Id, InvoiceRequestDTO InvoiceRequest)
    {
        try
        {
            var CurrentInvoice = await _context.Invoices.FindAsync(Id);
            if(CurrentInvoice == null) 
                return false;
            _mapper.Map(InvoiceRequest, CurrentInvoice);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    /// <inheritdoc/>
    public async Task<bool> DeleteInvoiceAsync(int Id)
    {
        try
        {
            var CurrentInvoice = await _context.Invoices.FindAsync(Id);
            if(CurrentInvoice == null) 
                return false;
             _context.Invoices.Remove(CurrentInvoice);
             _context.SaveChanges();
            return true;

        }
        catch (Exception ex)
        {
            return false;
        }
    }
   
}
