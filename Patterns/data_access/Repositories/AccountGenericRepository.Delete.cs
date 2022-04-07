
namespace DataAccess.Repositories
{
  public partial class AccountGenericRepository
  {
    public bool Delete(long accountNumber)
    {
      var accountEntity = 
        GetOne(
          whereCondition: a => a.AccountNumber == accountNumber);
      
      var accountRemoved = Remove(
          entity: accountEntity);
      
      if (accountRemoved)
        _unitOfWork.Commit();

      return accountRemoved;
    }

  }
}
