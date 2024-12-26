using AutoMapper;
using PaymentModule.DTOs.RefundDTO;
using PaymentModule.Entities;

namespace PaymentModule.Mappings;
/// <summary>
/// class to Create Mapping to all related to Refund 
/// </summary> 
public class RefundMapping : Profile
{
    public RefundMapping()
    {
        /// <summary>Create Map from RefundRequestDTO to Refund </summary>
        CreateMap<RefundRequestDTO, Refund>();

        /// <summary>Create Map from Refund to RefundResponseDTO and versevise </summary>
        CreateMap<Refund, RefundResponseDTO>().ReverseMap(); 
    }
}
