using shared.DatabaseContext;
using shared.Shared;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using use_cases._Interfaces;

namespace use_cases.Movements.Commands
{
  [ScopedService]
  public interface IDeleteMovement
  {
    IDeleteMovement WithContext(IUnitOfWork unitOfWork);

    UseCaseResult<bool, Failure> Execute(long movementId);
  }

  public class DeleteMovement : IDeleteMovement
  {
    readonly IMovementRepository movementRepository;

    public DeleteMovement(IMovementRepository movementRepository)
    {
      this.movementRepository = movementRepository;
    }

    public IDeleteMovement WithContext(IUnitOfWork unitOfWork)
    {
      movementRepository.WithContext(unitOfWork);
      return this;
    }

    public UseCaseResult<bool, Failure> Execute(long movementId)
    {
      return movementRepository.Delete(
        movementId: movementId);
    }
  }
}
