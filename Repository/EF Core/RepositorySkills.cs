using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositorySkills: RepositoryBase<Skills>, IRepositorySkills
    {
        private readonly RepositoryContext _context;
        public RepositorySkills(RepositoryContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<Skills> GetSkills(int id, bool trackchanges) => GenericReadExpression(x => x.SkillId == id, trackchanges);

    }
}
