using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesMind.Application.Commands.Customers;
using SalesMind.Application.Models.Customers;
using SalesMind.Application.Queries;
using SalesMind.Application.Services;

namespace SalesMind.API.Controllers;
[Route("api/v1/tenants/{tenantId:guid}/[controller]")]
[ApiController]
public class CustomersController(IMediator mediator, IUserContext userContext, ICustomerQueries customerQueries) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(Guid tenantId, [FromBody] CustomerRequest request)
    {
        var command = new AddCustomerCommand(tenantId, userContext.UserId, request);
        var customer = await mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { tenantId, id = customer.Id }, customer);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid tenantId, int id)
    {
        var customer = await customerQueries.GetById(tenantId, id);
        if (customer == null) return NotFound();
        return Ok(customer);
    }
}
