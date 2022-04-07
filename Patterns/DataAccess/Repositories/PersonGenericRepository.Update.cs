using DataAccess.Generic;
using DataAccess.Interfaces;
using Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
  public partial class PersonGenericRepository
  {
    public async Task<bool> Update(Person person)
    {
      return
        await UpdateAsync(
          entity: person);
    }

  }
}
