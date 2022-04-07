using shared.Domain;

namespace DataAccess.Repositories
{
  public partial class AccountGenericRepository
  {
    public new bool Update(Account account)
    {
      var accountUpdated =
         Update(
          entity: account);

      if (accountUpdated)
        _unitOfWork.Commit();

      return accountUpdated;
    }

  }
}
