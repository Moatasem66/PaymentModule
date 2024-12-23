using AutoMapper;
using PaymentModule.DTOs.DiscountDTO;
using PaymentModule.DTOs.InvoiceDTO;
using PaymentModule.Entities;

namespace PaymentModule.Mappings;
/// <summary>
/// class to Create Mapping to all related to Discount 
/// </summary> 
public class DiscountMapping : Profile
{
    public DiscountMapping()
    {
        /// <summary>Create Map from Request to Discount </summary>
        CreateMap<DiscountRequestDTO, Discount>();

        /// <summary>Create Map from Discount to Response </summary>
        CreateMap<Discount, DiscountResponseDTO>();
    }
}
