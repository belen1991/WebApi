using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace use_cases.Clients.Models
{
  public class ClientModel : PersonModel
  {
    public long ClientId { get; set; }
    public string Password { get; set; }
    public bool Status { get; set; }

    public ClientModel SetPersonModel(PersonModel personModel)
    {
      PersonId = personModel.PersonId;
      Name = personModel.Name;
      Gender = personModel.Gender;
      Age = personModel.Age;
      DocumentNumber = personModel.DocumentNumber;
      Address = personModel.Address;
      Phone = personModel.Phone;
      return this;
    }
  }
}
