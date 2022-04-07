using Newtonsoft.Json;
using shared.DatabaseContext;
using shared.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using use_cases._Interfaces;
using use_cases.Accounts.Models;

namespace use_cases.Accounts.Queries
{
  [ScopedService]
  public interface IGetAccountByNumber
  {
    IGetAccountByNumber WithContext(IUnitOfWork unitOfWork);

    UseCaseResult<AccountModel, Failure> Execute(long accountNumber);
  }
  public class GetAccountByNumber: IGetAccountByNumber
  {
    readonly IAccountRepository accountRepository;

    public GetAccountByNumber(
      IAccountRepository accountRepository)
    {
      this.accountRepository = accountRepository;
    }

    public IGetAccountByNumber WithContext(IUnitOfWork unitOfWork)
    {
      accountRepository.WithContext(unitOfWork);
      return this;
    }

    public UseCaseResult<AccountModel, Failure> Execute(long accountNumber)
    {
      return
        JsonConvert
            .DeserializeObject<AccountModel>(
              JsonConvert.SerializeObject(
                  accountRepository.GetOne(
                    accountNumber: accountNumber)));
    }

  }
}
