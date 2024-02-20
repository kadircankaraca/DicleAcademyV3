using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositoryStudentsSay : RepositoryBase<StudentsSay>, IRepositoryStudentsSay
    {
        private readonly RepositoryContext _context;
        public RepositoryStudentsSay(RepositoryContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<StudentsSay> GetStudentsSay(int id, bool trackchanges) => GenericReadExpression(x => x.StudentsSayId == id, trackchanges);

    }
}
