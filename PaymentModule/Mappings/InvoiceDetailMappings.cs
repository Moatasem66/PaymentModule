using AutoMapper;
using PaymentModule.DTOs.InvoiceDetailDTO;
using PaymentModule.Entities;

namespace PaymentModule.Mappings;

public class InvoiceDetailMappings : Profile
{
    public InvoiceDetailMappings()
    {
        CreateMap<InvoiceDetailRequestDTO, InvoiceDetail>() ;

        CreateMap<InvoiceDetail, InvoiceDetailResponseDTO>() ;

    }
}
