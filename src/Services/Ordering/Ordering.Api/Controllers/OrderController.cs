using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;

namespace Ordering.Api.Controllers
{
    public class OrderController : BaseController
    {
        [HttpGet("userName", Name = "GetOrder")]
        [ProducesResponseType(typeof(IEnumerable<OrdersVm>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrdersVm>>> GetOrdersByUsername(string userName)
        {
            var query = new GetOrdersListQuery(userName);

            var orders = await Mediator.Send(query);

            return Result(orders);
        }

        [HttpPost(Name = "CheckoutOrder")]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CheckoutOrder([FromBody] CheckoutOrderCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var command = new DeleteOrderCommand { Id = id };

            await Mediator.Send(command);

            return Ok();
        }
    }
}