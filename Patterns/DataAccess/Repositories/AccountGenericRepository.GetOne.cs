using DataAccess.Generic;
using DataAccess.Interfaces;
using Entities.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
  public partial class AccountGenericRepository
  {
    public async Task<Account> GetOne(long accountNumber)
    {
      var accountTable = await GetAsync(
          whereCondition: a => a.AccountNumber == accountNumber);

      return
        JsonConvert
          .DeserializeObject<Account>(
            JsonConvert.SerializeObject(
                accountTable));

    }

  }
}
