using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryInstructors: IRepositoryBase<Instructors>
    {
        IQueryable<Instructors> GetInstructors(int id, bool trackchanges);
    }
}
