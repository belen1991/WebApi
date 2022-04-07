using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shared.DatabaseContext;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using use_cases.Clients.Commands;
using use_cases.Clients.Models;
using use_cases.Clients.Queries;
using WebApi.Shared;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {

    /// <summary>
    /// Retrieves the list of clients.
    /// </summary>
    /// <param name="useCase">Use case that retrieves the list of clients</param>
    /// <param name="_unitOfWork"></param>
    /// <response code="200">A clients list</response>   
    [HttpGet]
    [ProducesResponseType(typeof(List<ClientModel>), StatusCodes.Status200OK)]
    public IActionResult Get(
      [FromServices] IGetManyClients useCase,
      [FromServices] IUnitOfWork _unitOfWork)
    {
      var result = useCase
        .WithContext(unitOfWork: _unitOfWork)
        .Execute();

      if (result.NoResult()) return NotFound();
      if (result.AccessDenied()) return Unauthorized();
      if (result.UseCaseError()) return BadRequest(result.GetUseCaseErrorReason());

      return Ok(result.Payload());
    }

    /// <summary>
    /// Retrieves a client by Id.
    /// </summary>
    /// <param name="useCase">Use case that retrieves the client</param>
    /// <param name="_unitOfWork"></param>
    /// <param name="id">Client identifier</param>
    /// <response code="200">A clients list</response>   
    [HttpGet("get-one/{id}")]
    [ProducesResponseType(typeof(ClientModel), StatusCodes.Status200OK)]
    public IActionResult GetOneById(
      [FromServices] IGetClientById useCase,
      [FromServices] IUnitOfWork _unitOfWork,
      [FromRoute][Required] long id)
    {
      var result = useCase
        .WithContext(unitOfWork: _unitOfWork)
        .Execute(clientId: id);

      if (result.NoResult()) return NotFound();
      if (result.AccessDenied()) return Unauthorized();
      if (result.UseCaseError()) return BadRequest(result.GetUseCaseErrorReason());

      return Ok(result.Payload());
    }

    /// <summary>
    /// Retrieves a client by Document Number.
    /// </summary>
    /// <param name="useCase">Use case that retrieves the client</param>
    /// <param name="_unitOfWork"></param>
    /// <param name="documentNumber">Client document number identifier</param>
    /// <response code="200">A clients list</response>   
    [HttpGet("get-one-by-document-number/{documentNumber}")]
    [ProducesResponseType(typeof(ClientModel), StatusCodes.Status200OK)]
    public IActionResult GetOneByDocumentNumber(
      [FromServices] IGetClientByDocumentNumber useCase,
      [FromServices] IUnitOfWork _unitOfWork,
      [FromRoute][Required] string documentNumber)
    {
      var result = useCase
        .WithContext(unitOfWork: _unitOfWork)
        .Execute(documentNumber: documentNumber);

      if (result.NoResult()) return NotFound();
      if (result.AccessDenied()) return Unauthorized();
      if (result.UseCaseError()) return BadRequest(result.GetUseCaseErrorReason());

      return Ok(result.Payload());
    }


    public class ClientPayloaad
    {
      public string Password { get; set; }
      public bool Status { get; set; }
      public string Name { get; set; }
      public string Gender { get; set; }
      public string Age { get; set; }
      public string DocumentNumber { get; set; }
      public string Address { get; set; }
      public string Phone { get; set; }

    }

    /// <summary>
    /// Insert a client.
    /// </summary>
    /// <param name="useCase">Use case that insert a client</param>
    /// <param name="_unitOfWork"></param>
    /// <response code="200">The client</response>   
    [HttpPost]
    [ProducesResponseType(typeof(ClientModel), StatusCodes.Status200OK)]
    public IActionResult InsertClient(
      [FromServices] IInsertClientAsPerson useCase,
      [FromServices] IUnitOfWork _unitOfWork,
      [FromBody] ClientPayloaad payload) 
    {
      var result = useCase
        .WithContext(unitOfWork: _unitOfWork)
        .Execute( client:
          JsonConvert
            .DeserializeObject<ClientModel>(
              JsonConvert.SerializeObject(payload)));

      if (result.NoResult()) return NotFound();
      if (result.AccessDenied()) return Unauthorized();
      if (result.UseCaseError()) return BadRequest(result.GetUseCaseErrorReason());

      return Ok(result.Payload());
    }

    /// <summary>
    /// Update a client.
    /// </summary>
    /// <param name="useCase">Use case that update a client</param>
    /// <param name="_unitOfWork"></param>
    /// <param name="id">Client identifier</param>
    /// <response code="200">The client</response>   
    [HttpPatch("{id}")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public IActionResult UpdateClient(
      [FromServices] IUpdateClientAsPerson useCase,
      [FromServices] IUnitOfWork _unitOfWork,
      [FromRoute][Required] long id,
      [FromBody] ClientPayloaad payload)
    {
      var result = useCase
        .WithContext(unitOfWork: _unitOfWork)
        .Execute(
          clientId: id, 
          client:
            JsonConvert
              .DeserializeObject<ClientModel>(
                JsonConvert.SerializeObject(payload)));

      if (result.NoResult()) return NotFound();
      if (result.AccessDenied()) return Unauthorized();
      if (result.UseCaseError()) return BadRequest(result.GetUseCaseErrorReason());

      return Ok(result.Payload());
    }

    /// <summary>
    /// Delete a client.
    /// </summary>
    /// <param name="useCase">Use case that update a client</param>
    /// <param name="_unitOfWork"></param>
    /// <param name="id">Client identifier</param>
    /// <response code="200">If the client was deleted</response>   
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public IActionResult DeleteClient(
      [FromServices] IDeleteClientAsPerson useCase,
      [FromServices] IUnitOfWork _unitOfWork,
      [FromRoute][Required] long id)
    {
      var result = useCase
        .WithContext(unitOfWork: _unitOfWork)
        .Execute(clientId:id);

      if (result.NoResult()) return NotFound();
      if (result.AccessDenied()) return Unauthorized();
      if (result.UseCaseError()) return BadRequest(result.GetUseCaseErrorReason());

      return Ok(result.Payload());
    }

  }

}
