using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using MoveIT.Api.Dto;
using MoveIT.Core.Models;
using MoveIT.Core.Services;
using MoveIT.Api.Validators;

namespace MoveIT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : _ProtectedBaseController
    {
        private readonly IOrderService _orderService;
        private readonly IMovingProposalService _movingProposalService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMovingProposalService movingProposalService, IHttpContextAccessor httpContextAccessor, IMapper mapper) 
            : base(httpContextAccessor)
        {
            _orderService = orderService;
            _movingProposalService = movingProposalService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetAll()
        {
            var items = await _orderService.GetAll(new Guid(AuthenticatedUserId));
            var mapped = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDetails>>(items);

            return Ok(mapped);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetails>> GetById(Guid id)
        {
            var item = await _orderService.Get(id, new Guid(AuthenticatedUserId));
            if (item == null)
            {
                return NotFound();
            }
            var mapped = _mapper.Map<Order, OrderDetails>(item);

            return Ok(mapped);
        }

        [HttpGet("proposal/{id}")]
        public async Task<ActionResult<OrderDetails>> GetByMovingProposalId(Guid id)
        {
            var item = await _orderService.GetByMovingProposalId(id, new Guid(AuthenticatedUserId));
            if (item == null)
            {
                return NotFound();
            }

            var mapped = _mapper.Map<Order, OrderDetails>(item);

            return Ok(mapped);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Create([FromBody] CreateOrder createOrder)
        {
            var validator = ValidatorFactory.GetVaidator<CreateOrder>();
            var validatonResult = validator.Validate(createOrder);
            if (!validatonResult.IsValid)
            {
                return BadRequest(validatonResult.Errors);
            }

            var movingProposal = await _movingProposalService.Get(createOrder.MovingProposalId, new Guid(AuthenticatedUserId));
            if (movingProposal == null)
                return BadRequest($"The moving order with is {createOrder.MovingProposalId} or is not accessible");

            var order = await _orderService.GetByMovingProposalId(createOrder.MovingProposalId, new Guid(AuthenticatedUserId));
            if (order != null)
                return BadRequest($"An order for the proposal with id {createOrder.MovingProposalId} has already been created");

            var mapped = _mapper.Map<CreateOrder, Order>(createOrder);
            var item = await _orderService.Create(mapped);
            var result = _mapper.Map<Order, OrderDetails>(item);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var item = await _orderService.Get(id, new Guid(AuthenticatedUserId));
            if (item == null)
                return NotFound();

            await _orderService.Delete(item);

            return NoContent();
        }
    }
}
