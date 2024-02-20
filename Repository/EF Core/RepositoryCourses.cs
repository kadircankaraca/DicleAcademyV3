using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositoryCourses: RepositoryBase<Courses>, IRepositoryCourses
    {
        private readonly RepositoryContext _context;
        public RepositoryCourses(RepositoryContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<Courses> GetCourses(int id, bool trackchanges) => GenericReadExpression(x => x.CourseId == id, trackchanges);
        public List<Courses> GetCoursesByCategoryId(int id) 
        {
           var data = _context.Courses.Where(x => x.CategoryId == id).ToList();
            return data;   
        }
    }
}
