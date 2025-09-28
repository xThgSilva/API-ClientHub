using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.GettAll;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RequestClientJson request)
        {
            try
            {
                var useCase = new RegisterClientUseCase();

                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch(ProductClientHubException e)
            {
                var errors = e.GetErrors();

                return BadRequest(new ResponseErrorMessageJson(errors));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                      new ResponseErrorMessageJson("Erro desconhecido."));
            }
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllClientsJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            var useCase = new GetAllClientsUseCase();

            var response = useCase.Execute();
            
            if (response.Clients.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet("by-id")]
        // [Route("{id}")]
        public IActionResult GetById([FromRoute]Guid id)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
