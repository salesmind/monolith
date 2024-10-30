using System;
using AutoMapper;
using MediatR;
using SalesMind.Application.Models.Customers;
using SalesMind.Domain.Entities;
using SalesMind.Infrastructure.Data;

namespace SalesMind.Application.Commands.Customers;

public class AddCustomerCommandHandler(IMapper mapper, ITenantDbProvider tenantDbProvider) : IRequestHandler<AddCustomerCommand, CustomerDTO>
{
    public async Task<CustomerDTO> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            Name = request.Customer.Name,
            Description = request.Customer.Description,
            CreatedBy = request.UserId,
            ModifiedBy = request.UserId,
        };
        using var db = tenantDbProvider.GetOrCreate(request.TenantId);
        await db.Customers.AddAsync(customer);
        await db.SaveEntitiesAsync(cancellationToken);
        return mapper.Map<CustomerDTO>(customer);
    }
}
