using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.CQRS.Command.AddOrder;
using Order.CQRS.Command.DeleteOrder;
using Order.CQRS.Command.UpdateOrder;
using Order.CQRS.Query.GetAllOrders;
using Order.CQRS.Query.GetOrder;

namespace Order.Controllers
{
    [ApiController]
    [Route("Orders")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet()]
        public async Task<ActionResult> Get()
        {
            var result = await mediator.Send(new GetAllOrdersQuery());
            return Ok(result);
        }

        [HttpGet("Id")]
        public async Task<ActionResult> GetById(Guid Id)
        {
            var result = await mediator.Send(new GetOrderByIdQuery(Id));
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add(string CarMaker, string Model, int Year)
        {
            var result = await mediator.Send(new AddOrderCommand(CarMaker, Model, Year));
            return Ok(result);
        }

        [HttpPatch("Update")]
        public async Task<ActionResult> Update(Guid Id, string CarMaker, string Model, int Year)
        {
            var result = await mediator.Send(new UpdateOrderCommand(Id, CarMaker, Model, Year));
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete()
        {
            var result = await mediator.Send(new DeleteAllOrdersCommand());
            return Ok(result);
        }
    }
}
