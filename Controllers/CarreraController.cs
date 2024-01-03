using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaPrayaga.Application;

namespace SistemaPrayaga
{
    public class CarreraController : BaseApiController
    {
        public CarreraController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create(CreateCarreraComand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(Create), result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create(UpdateCarreraComand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}