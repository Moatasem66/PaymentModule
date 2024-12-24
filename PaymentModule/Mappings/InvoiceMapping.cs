using PaymentModule.DTOs;
using PaymentModule.Entities;
using AutoMapper;
using PaymentModule.DTOs.InvoiceDTO;

namespace PaymentModule.Mappings;

/// <summary>
/// class to Create Mapping to all related to Invoice 
/// </summary> 
public class InvoiceMapping : Profile
{
    public InvoiceMapping()
    {
        /// <summary>Create Map from Request to Invoice </summary>
        CreateMap<InvoiceRequestDTO, Invoice>().ReverseMap();
       

        /// <summary>Create Map from Invoice to Response </summary>
        CreateMap<Invoice, InvoiceResponseDTO>().ReverseMap();
    }
}
