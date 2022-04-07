using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shared.DatabaseContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using use_cases.Accounts.Commands;
using use_cases.Accounts.Models;
using use_cases.Accounts.Queries;
using WebApi.Shared;

namespace WebApi.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class AccountsController : ControllerBase
  {

    /// <summary>
    /// Retrieves the list of accounts.
    /// </summary>
    /// <param name="useCase">Use case that retrieves the list of accounts</param>
    /// <param name="_unitOfWork"></param>
    /// <response code="200">Account list</response>   
    [HttpGet]
    [ProducesResponseType(typeof(List<DetailAccountModel>), StatusCodes.Status200OK)]
    public IActionResult Get(
      [FromServices] IGetManyAccounts useCase,
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
    /// Retrieves the list of accounts by client.
    /// </summary>
    /// <param name="useCase">Use case that retrieves the list of accounts</param>
    /// <param name="_unitOfWork"></param>
    /// <param name="documentNumber">Client document number identifier</param>
    /// <response code="200">Account list</response>   
    [HttpGet("{documentNumber}")]
    [ProducesResponseType(typeof(List<DetailAccountModel>), StatusCodes.Status200OK)]
    public IActionResult GetAccountByClient(
      [FromServices] IGetAccountByClient useCase,
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

    public class AccountPayloaad
    {
      public long AccountNumber { get; set; }
      public string AccountType { get; set; }
      public double AccountInitialBalance { get; set; }
      public bool AccountStatus { get; set; }
    }

    /// <summary>
    /// Insert an account.
    /// </summary>
    /// <param name="useCase">Use case that insert an account</param>
    /// <param name="_unitOfWork"></param>
    /// <param name="documentNumber">Client document number identifier</param>
    /// <response code="200">The account</response>   
    [HttpPost("{documentNumber}")]
    [ProducesResponseType(typeof(AccountModel), StatusCodes.Status200OK)]
    public IActionResult InsertAccount(
      [FromServices] IInsertAccount useCase,
      [FromServices] IUnitOfWork _unitOfWork,
      [FromRoute][Required] string documentNumber,
      [FromBody] AccountPayloaad payload)
    {
      var result = useCase
        .WithContext(unitOfWork: _unitOfWork)
        .Execute(account:
            JsonConvert
              .DeserializeObject<AccountModel>(
                JsonConvert.SerializeObject(payload)), 
            documentNumber: 
              documentNumber);

      if (result.NoResult()) return NotFound();
      if (result.AccessDenied()) return Unauthorized();
      if (result.UseCaseError()) return BadRequest(result.GetUseCaseErrorReason());

      return Ok(result.Payload());
    }

    /// <summary>
    /// Delete an account.
    /// </summary>
    /// <param name="useCase">Use case that delete an account</param>
    /// <param name="_unitOfWork"></param>
    /// <param name="accountNumber">the number of the account</param>
    /// <response code="200">If the account was deleted</response>   
    [HttpDelete("{accountNumber}")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public IActionResult DeleteClient(
      [FromServices] IDeleteAccount useCase,
      [FromServices] IUnitOfWork _unitOfWork,
      [FromRoute][Required] long accountNumber)
    {
      var result = useCase
        .WithContext(unitOfWork: _unitOfWork)
        .Execute(accountNumber: accountNumber);

      if (result.NoResult()) return NotFound();
      if (result.AccessDenied()) return Unauthorized();
      if (result.UseCaseError()) return BadRequest(result.GetUseCaseErrorReason());

      return Ok(result.Payload());
    }

  }

}
