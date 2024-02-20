using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
        User GetUser(string id, bool trackChanges);
    }
}
