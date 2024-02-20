using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryCourses: IRepositoryBase<Courses>
    {
        IQueryable<Courses> GetCourses(int id, bool trackchanges);
        List<Courses> GetCoursesByCategoryId(int id);

    }
}
