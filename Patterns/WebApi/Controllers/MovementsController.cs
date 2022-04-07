using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shared.DatabaseContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using use_cases.Movements.Commands;
using use_cases.Movements.Models;
using use_cases.Movements.Queries;
using WebApi.Shared;

namespace WebApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class MovementsController : ControllerBase
  {
    public class MovementPayloaad
    {
      public double MovementValue { get; set; }
    }

    /// <summary>
    /// Insert a movement.
    /// </summary>
    /// <param name="useCase">Use case that insert a movement</param>
    /// <param name="_unitOfWork"></param>
    /// <param name="accountNumber">Account number identifier</param>
    /// <response code="200">The movement</response>   
    [HttpPost("{accountNumber}")]
    [ProducesResponseType(typeof(MovementModel), StatusCodes.Status200OK)]
    public IActionResult InsertMovement(
      [FromServices] IInsertMovement useCase,
      [FromServices] IUnitOfWork _unitOfWork,
      [FromRoute][Required] long accountNumber,
      [FromBody] MovementPayloaad payload)
    {
      var result = useCase
        .WithContext(unitOfWork: _unitOfWork)
        .Execute(movement:
            JsonConvert
              .DeserializeObject<MovementModel>(
                JsonConvert.SerializeObject(payload)),
            accountNumber:
              accountNumber);

      if (result.NoResult()) return NotFound();
      if (result.AccessDenied()) return Unauthorized();
      if (result.UseCaseError()) return BadRequest(result.GetUseCaseErrorReason());

      return Ok(result.Payload());
    }


    /// <summary>
    /// Retrieves the report of movements by date and client.
    /// </summary>
    /// <param name="useCase">Use case that retrieves the list of movements</param>
    /// <param name="_unitOfWork"></param>
    /// <param name="documentNumber">Client document number identifier</param>
    /// <param name="date">Date (one day), in the following format “yyyy-mm-dd”</param>
    /// <response code="200">Account list</response>   
    [HttpGet("report-by-date-client/{documentNumber}/{date}")]
    [ProducesResponseType(typeof(List<DetailMovementModel>), StatusCodes.Status200OK)]
    public IActionResult GetAccountByClient(
      [FromServices] IGetMovementsReport useCase,
      [FromServices] IUnitOfWork _unitOfWork,
      [FromRoute][Required] string documentNumber,
      [FromRoute][Required] string date)
    {
      var result = useCase
        .WithContext(unitOfWork: _unitOfWork)
        .Execute(
          documentNumber: documentNumber,
          dateTime: DateTime.Parse(date));

      if (result.NoResult()) return NotFound();
      if (result.AccessDenied()) return Unauthorized();
      if (result.UseCaseError()) return BadRequest(result.GetUseCaseErrorReason());

      return Ok(result.Payload());
    }

  }

}
