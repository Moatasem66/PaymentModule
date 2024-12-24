using AutoMapper;
using PaymentModule.DTOs.DiscountDTO;
using PaymentModule.DTOs.InvoiceDTO;
using PaymentModule.DTOs.PaymentDTO;
using PaymentModule.DTOs.PaymentHistoryDTO;
using PaymentModule.Entities;

namespace PaymentModule.Mappings;
/// <summary>
/// class to Create Mapping to all related to Payment 
/// </summary> 
public class PaymentHistoryMapping : Profile
{
    public PaymentHistoryMapping()
    {
        /// <summary>Create Map from Request to Payment </summary>
        CreateMap<PaymentHistoryRequestDTO, PaymentHistory>().ReverseMap();

        /// <summary>Create Map from Payment to Response </summary>
        CreateMap<PaymentHistory, PaymentHistoryResponseDTO>();
    }
}
