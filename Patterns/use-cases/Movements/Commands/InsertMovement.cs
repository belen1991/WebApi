using Newtonsoft.Json;
using shared.DatabaseContext;
using shared.Domain;
using shared.Shared;
using System;
using System.Linq;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using use_cases._Interfaces;
using use_cases.Movements.Models;

namespace use_cases.Movements.Commands
{
  [ScopedService]
  public interface IInsertMovement
  {
    IInsertMovement WithContext(IUnitOfWork unitOfWork);

    UseCaseResult<MovementModel, Failure> Execute(long accountNumber, MovementModel movement);
  }

  public class InsertMovement : IInsertMovement
  {
    readonly IAccountRepository accountRepository;
    readonly IMovementRepository movementRepository;

    public InsertMovement(
      IAccountRepository accountRepository,
      IMovementRepository movementRepository)
    {
      this.accountRepository = accountRepository;
      this.movementRepository = movementRepository;
    }

    public IInsertMovement WithContext(IUnitOfWork unitOfWork)
    {
      accountRepository.WithContext(unitOfWork);
      movementRepository.WithContext(unitOfWork);
      return this;
    }

    public UseCaseResult<MovementModel, Failure> Execute(long accountNumber, MovementModel movement)
    {
      var accountFounded =
          accountRepository.GetOne(
            accountNumber: accountNumber);

      if (accountFounded == null)
        return new UseCaseError() { reason = new { AccountNotExist = true } };

      if (movement.MovementValue > 0)
        movement.MovementType = "Credito";
      else
      {
        var movementsPerDay = Math.Abs(
          movementRepository.
            GetManyByDate(
              accountNumber: accountNumber,
              date: DateTime.Now)
          .Where(m => 
            m.MovementType.Equals("Debito"))
          .Sum(m => 
            m.MovementValue));

        movementsPerDay += Math.Abs(movement.MovementValue);
        if (movementsPerDay > 1000)
          return new UseCaseError() { reason = new { ExcceededTheDailyAmount = true } };
        
        movement.MovementType = "Debito";
      }
      movement.MovementDate = DateTime.Now;
      movement.AccountNumber = accountNumber;
      
      var lastMovement = 
        movementRepository.
          GetLastMovement(
            accountNumber: accountNumber);

      var actualBalance = lastMovement == null ? 0 :
        lastMovement.MovementBalance + lastMovement.MovementValue;

      if (movement.MovementValue < 0)
      {
        if(actualBalance<Math.Abs(movement.MovementValue))
          return new UseCaseError() { reason = new { BalanceNotAvailable = true } };
      }

      movement.MovementBalance= actualBalance;

      var movementId =
        movementRepository.Create(
          movement: JsonConvert
                .DeserializeObject<Movement>(
                  JsonConvert.SerializeObject(
                      movement)));
      movement.MovementId = movementId;
      return movement;
    }

  }
}
