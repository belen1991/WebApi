using DataAccess.Generic;
using Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
  public interface IClientGenericRepository
  {
    IClientGenericRepository WithContext(
      UnitOfWork unitOfWork);

    Task<long> Create(Client client);
    Task<bool> Update(Client client);
    Task<Client> GetOne(long clientId);
    Task<List<Client>> GetMany();
    Task<bool> Delete(long clientId);
  }

}
