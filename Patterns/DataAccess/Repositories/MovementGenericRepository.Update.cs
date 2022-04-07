using DataAccess.Generic;
using DataAccess.Interfaces;
using Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
  public partial class MovementGenericRepository
  {
    public async Task<bool> Update(Movement movement)
    {
      return
        await UpdateAsync(
          entity: movement);
    }

  }
}
