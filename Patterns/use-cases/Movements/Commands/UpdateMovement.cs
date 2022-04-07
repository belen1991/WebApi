using Newtonsoft.Json;
using shared.DatabaseContext;
using shared.Domain;
using shared.Shared;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using use_cases._Interfaces;
using use_cases.Movements.Models;

namespace use_cases.Movements.Commands
{
  [ScopedService]
  public interface IUpdateMovement
  {
    IUpdateMovement WithContext(IUnitOfWork unitOfWork);

    UseCaseResult<bool, Failure> Execute(MovementModel movement);
  }

  public class UpdateMovement : IUpdateMovement
  {
    readonly IMovementRepository movementRepository;

    public UpdateMovement(IMovementRepository movementRepository)
    {
      this.movementRepository = movementRepository;
    }

    public IUpdateMovement WithContext(IUnitOfWork unitOfWork)
    {
      movementRepository.WithContext(unitOfWork);
      return this;
    }

    public UseCaseResult<bool, Failure> Execute(MovementModel movement)
    {
      return movementRepository.Update(
        movement: JsonConvert
              .DeserializeObject<Movement>(
                JsonConvert.SerializeObject(
                    movement)));
    }
  }
}
