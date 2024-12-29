using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaymentModule.Context;
using PaymentModule.Contracts;
using PaymentModule.DTOs.InvoiceDetailDTO;
using PaymentModule.DTOs.InvoiceDTO;
using PaymentModule.Entities;

namespace PaymentModule.Services;
/// <summary>
/// Service class responsible for managing discounts.
/// </summary>
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
        var Response = await _context.Invoices
                                              .Include(d => d.Discount)
                                              .Include(x => x.InvoiceDetails)
                                              .FirstOrDefaultAsync(x => x.Id == id);

        return Response == null ? null : _mapper.Map<InvoiceResponseDTO>(Response);
    }
    /// <inheritdoc/>
    public async Task<List<InvoiceResponseDTO>> GetAllInvoicesAsync()
    {
        var ResponseLst = await _context.Invoices
                                            .Include (d => d.InvoiceDetails)
                                            .ToListAsync();

        return _mapper.Map<List<InvoiceResponseDTO>>(ResponseLst);
    }
    /// <inheritdoc/>
    public async Task<InvoiceResponseDTO> CreateInvoiceAsync(InvoiceRequestDTO invoiceRequest)
    {
        try
        {
            var Invoice = _mapper.Map<Invoice>(invoiceRequest);

            var TotalAmount = invoiceRequest.InvoiceDetails.Sum(d => d.Quantity * d.UnitPrice);
            Invoice.TotalAmount = TotalAmount;

            Invoice.FinalAmount = CalcFinalAmountForInvoice(invoiceRequest.DiscountId, TotalAmount);

            _context.Invoices.Add(Invoice);

            await _context.SaveChangesAsync();

            var response = _mapper.Map<InvoiceResponseDTO>(Invoice);

            response.InvoiceDetails = await CreateInvoiceDetails(Invoice.Id , invoiceRequest.InvoiceDetails);

            return response;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    /// <inheritdoc/>
    public async Task<bool> UpdateInvoiceAsync(int id, InvoiceRequestDTO invoiceRequest)
    {
        try
        {
            var CurrentInvoice = await _context.Invoices.Include(i => i.InvoiceDetails).FirstOrDefaultAsync( x => x.Id == id);
            if(CurrentInvoice == null) 
                return false;

            if (CurrentInvoice.InvoiceDetails != null)
            {
                _context.InvoiceDetails.RemoveRange(CurrentInvoice.InvoiceDetails);
            }

            _mapper.Map(invoiceRequest, CurrentInvoice);

            var TotalAmount = invoiceRequest.InvoiceDetails.Sum(d => d.Quantity * d.UnitPrice);
           
            CurrentInvoice.TotalAmount = TotalAmount;

            CurrentInvoice.FinalAmount = CalcFinalAmountForInvoice(invoiceRequest.DiscountId, TotalAmount);

            await _context.SaveChangesAsync();

            var InvoiceResponse = _mapper.Map<InvoiceResponseDTO>(CurrentInvoice);

            InvoiceResponse.InvoiceDetails = await CreateInvoiceDetails(id, invoiceRequest.InvoiceDetails);
          
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
    /// <inheritdoc/>
    public async Task<List<InvoiceResponseDTO>?> GetInvoiceByDiscountIdAsync(int discountId)
    {
        var InvoiceCollection  = await _context.Invoices.Where(x => x.DiscountId == discountId).ToListAsync();

        return InvoiceCollection == null ? null : _mapper.Map<List<InvoiceResponseDTO>>(InvoiceCollection)!;
    }
    /// <summary>
    /// method to Calc Final Amount After Apply Discount 
    /// </summary>
    /// <param name="discountId"></param>
    /// <param name="TotalAmount"></param>
    /// <returns></returns>
    private decimal CalcFinalAmountForInvoice(int? discountId , decimal TotalAmount)
    {
        try
        {
            if (discountId == 0 || discountId == null)
                return TotalAmount;
            var CurrentDiscount = _context.Discounts.Find(discountId);
            if (CurrentDiscount == null)
                return TotalAmount;

            return CurrentDiscount.Presentage == 0 ? TotalAmount : TotalAmount - (TotalAmount * (CurrentDiscount.Presentage / 100));
        }
        catch (Exception ex )
        {
            throw new Exception( $"there Error in Calc Final Amount please check  and the message to this error  : {ex.Message}");
        }
        
    }
    /// <summary>
    /// Method to Create Invoice Details take invoice id to add invoiceDetails to this Invoice 
    /// </summary>
    /// <param name="invoiceId"></param>
    /// <param name="invoiceDetailRequests"></param>
    /// <returns>List of InvoiceDetailResponseDTO</returns>
    private async Task<List<InvoiceDetailResponseDTO>> CreateInvoiceDetails (int invoiceId, List<InvoiceDetailRequestDTO> invoiceDetailRequests)
    {
        var InvoiceDetails = _mapper.Map<List<InvoiceDetail>>(invoiceDetailRequests);

        foreach (var InvoiceDetail in InvoiceDetails)
        {
            InvoiceDetail.InvoiceId = invoiceId;
            InvoiceDetail.TotalPrice = InvoiceDetail.Quantity * InvoiceDetail.UnitPrice;
        }

        _context.InvoiceDetails.AddRange(InvoiceDetails);
      
        await _context.SaveChangesAsync();
       
        return _mapper.Map<List<InvoiceDetailResponseDTO>>(InvoiceDetails);
    }
}
