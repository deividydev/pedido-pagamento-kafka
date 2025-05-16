using Application.Orders.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("[controller]/api")]
public class OrderController : Controller
{
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromServices] IMediator _mediator)
    {
        var request = new OrderParymentRequest(Guid.NewGuid(), 100);

        await _mediator.Send(request);

        return Ok("Send event sucessfully.");
    }
}
