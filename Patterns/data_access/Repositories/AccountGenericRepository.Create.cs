using shared.Domain;

namespace DataAccess.Repositories
{
  public partial class AccountGenericRepository
  {
    public new Account Create(Account account)
    {
      var accountCreated = 
        Create(
          entity: account);

      if (accountCreated != null)
        _unitOfWork.Commit();

      return 
        accountCreated == null ? null : 
          accountCreated;
    }


  }
}
