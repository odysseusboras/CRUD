using Business.Commands.Degree.CreateDegree;
using Business.Commands.Degree.DeleteDegree;
using Business.Commands.Degree.UpdateDegree;
using Business.Queries.Degree.GetDegrees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DegreeController : ControllerBase
    {
        private readonly ILogger<DegreeController> _logger;

        private readonly IMediator _mediator;

        public DegreeController(ILogger<DegreeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<DegreeDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {

            try
            {
                var request = new GetDegreesQuery();
                var result = await _mediator.Send(request, Request.HttpContext.RequestAborted);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        [HttpDelete(Name = "[controller]/delete")]
        [ProducesResponseType(typeof(DegreeDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] DeleteDegreeCommand command)
        {
            try
            {
                var result = await _mediator.Send(command, Request.HttpContext.RequestAborted);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        [HttpPut(Name = "[controller]/update")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(DegreeDTO), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateDegreeCommand command)
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
        [ProducesResponseType(typeof(DegreeDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateDegreeCommand command)
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
