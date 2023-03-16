using Business.Commands.CV.CreateCV;
using Business.Commands.CV.DeleteCV;
using Business.Commands.CV.UpdateCV;
using Business.Queries.CV.GetCVs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CVController : ControllerBase
    {

        private readonly ILogger<CVController> _logger;

        private readonly IMediator _mediator;

        public CVController(ILogger<CVController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CVDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute] Guid? id)
        {
            try
            {
                var request = new GetCVsQuery { Id = id };
                var result = await _mediator.Send(request, Request.HttpContext.RequestAborted);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }


        [HttpDelete(Name = "[controller]/delete")]
        [ProducesResponseType(typeof(CVDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] DeleteCVCommand command)
        {
            try
            {
                var result = await _mediator.Send(command, Request.HttpContext.RequestAborted);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        [HttpPut(Name = "[controller]/update")]
        [ProducesResponseType(typeof(CVDTO), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateCVCommand command)
        {
            try
            {
                var result = await _mediator.Send(command, Request.HttpContext.RequestAborted);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }

        }

        [HttpPost(Name = "[controller]/create")]
        [ProducesResponseType(typeof(CVDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromForm]CreateCVCommand command)
        {
            try
            {
                var result = await _mediator.Send(command, Request.HttpContext.RequestAborted);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

    }
}