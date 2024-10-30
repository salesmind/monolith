using SalesMind.Application.Models.Customers;

namespace SalesMind.Application.Queries;

public interface ICustomerQueries
{
    Task<CustomerDTO> GetById(Guid tenantId, int id);
}
