using AutoMapper;
using PaymentModule.DTOs.DiscountDTO;
using PaymentModule.DTOs.InvoiceDTO;
using PaymentModule.DTOs.PaymentDTO;
using PaymentModule.Entities;

namespace PaymentModule.Mappings;
/// <summary>
/// class to Create Mapping to all related to Payment 
/// </summary> 
public class PaymentMapping : Profile
{
    public PaymentMapping()
    {
        /// <summary>Create Map from Request to Payment </summary>
        CreateMap<PaymentRequestDTO, Payment>().ReverseMap();

        /// <summary>Create Map from Payment to Response </summary>
        CreateMap<Payment, PaymentResponseDTO>().ReverseMap();
    }
}
