using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using MoveIT.Api.Dto;
using MoveIT.Core.Models;
using MoveIT.Core.Services;
using Microsoft.AspNetCore.Http;
using MoveIT.Api.Validators;

namespace MoveIT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovingProposalsController : _ProtectedBaseController
    {
        private readonly IMovingProposalService _movingProposalService;
        private readonly IMapper _mapper;

        public MovingProposalsController(IMovingProposalService movingProposalService, IHttpContextAccessor httpContextAccessor, IMapper mapper) 
            : base(httpContextAccessor)
        {
            _movingProposalService = movingProposalService;
            _mapper = mapper;
        }
     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovingProposalDto>>> GetAll()
        {
            var items = await _movingProposalService.GetAll(new Guid(AuthenticatedUserId));
            var mapped = _mapper.Map<IEnumerable<MovingProposalPrice>, IEnumerable<MovingProposalDto>>(items);

            return Ok(mapped);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovingProposalDto>> GetById(Guid id)
        {
            var item = await _movingProposalService.Get(id, new Guid(AuthenticatedUserId));
            if (item == null)
                return NotFound();

            var mapped = _mapper.Map<MovingProposalPrice, MovingProposalDto>(item);

            return Ok(mapped);
        }


        [HttpPost]
        public async Task<ActionResult<MovingProposalDto>> Create([FromBody]CreateMovingProposal createMovingProposal)
        {
            var validator = ValidatorFactory.GetVaidator<CreateMovingProposal>();
            var validatonResult = validator.Validate(createMovingProposal);
            if (!validatonResult.IsValid)
            {
                return BadRequest(validatonResult.Errors);
            }

            var mapped = _mapper.Map<CreateMovingProposal, MovingProposal>(createMovingProposal);
            mapped.UserId = new Guid(AuthenticatedUserId);
            var item = await _movingProposalService.Create(mapped);
            var result = _mapper.Map<MovingProposalPrice, MovingProposalDto>(item);

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody]CreateMovingProposal updateMovingProposal)
        {
            var validator = ValidatorFactory.GetVaidator<CreateMovingProposal>();
            var validatonResult = validator.Validate(updateMovingProposal);
            if (!validatonResult.IsValid)
            {
                return BadRequest(validatonResult.Errors);
            }

            var movingProposal = await _movingProposalService.Get(id, new Guid(AuthenticatedUserId));
            if (movingProposal == null)
                return NotFound();

            var updated = _mapper.Map<CreateMovingProposal, MovingProposal>(updateMovingProposal);
            updated.Id = id;
            await _movingProposalService.Update(updated);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var item = await _movingProposalService.Get(id, new Guid(AuthenticatedUserId));
            if (item == null)
                return NotFound();

            await _movingProposalService.Delete(item);

            return NoContent();
        }
    }
}
