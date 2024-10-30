using AutoMapper;
using SalesMind.Application.Models.Customers;
using SalesMind.Domain.Entities;

namespace SalesMind.Application.MappingProfiles;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<Customer, CustomerDTO>(MemberList.Destination);
    }
}
