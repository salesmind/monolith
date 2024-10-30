using MediatR;
using SalesMind.Application.Models.Customers;

namespace SalesMind.Application.Commands.Customers;
public record AddCustomerCommand(Guid TenantId, string UserId, CustomerRequest Customer) : IRequest<CustomerDTO>;