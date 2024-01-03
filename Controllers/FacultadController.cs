using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaPrayaga.Application;

namespace SistemaPrayaga
{
    public class FacultadController : BaseApiController
    {
        public FacultadController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create(CreateFacultadComand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(Create), result);
        }
    }
}