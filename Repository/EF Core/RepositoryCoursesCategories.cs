using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositoryCoursesCategories : RepositoryBase<CoursesCategories>, IRepositoryCoursesCategories
    {
        private readonly RepositoryContext _context;
        public RepositoryCoursesCategories(RepositoryContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<CoursesCategories> GetCoursesCategories(int id, bool trackchanges) => GenericReadExpression(x => x.CategoryId == id, trackchanges);

    }
}
