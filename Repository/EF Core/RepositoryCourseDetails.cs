using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositoryCourseDetails : RepositoryBase<CourseDetails>, IRepositoryCourseDetails
    {
        private readonly RepositoryContext _context;
        public RepositoryCourseDetails(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<CourseDetails> GetCourseDetails(int id, bool trackchanges) => GenericReadExpression(x => x.CourseDetailsId == id, trackchanges);


    }
}
