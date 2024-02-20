using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositorySkills: IRepositoryBase<Skills>
    {
        IQueryable<Skills> GetSkills(int id, bool trackchanges);
    }
}
