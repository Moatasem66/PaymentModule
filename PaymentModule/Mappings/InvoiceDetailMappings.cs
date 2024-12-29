using AutoMapper;
using PaymentModule.DTOs.InvoiceDetailDTO;
using PaymentModule.Entities;

namespace PaymentModule.Mappings;
/// <summary>
/// class to Create Mapping to all related to InvoiceDetial  
/// </summary> 
public class InvoiceDetailMappings : Profile
{
    public InvoiceDetailMappings()
    {

        /// <summary>Create Map from InvoiceDetailRequestDTO to INvoiceDetail </summary>
        CreateMap<InvoiceDetailRequestDTO, InvoiceDetail>() ;
       
        /// <summary>Create Map from INvoiceDetail to InvoiceDetailResponseDTO </summary>
        CreateMap<InvoiceDetail, InvoiceDetailResponseDTO>() ;

    }
}
