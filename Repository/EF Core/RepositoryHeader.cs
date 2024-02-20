using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositoryHeader : RepositoryBase<Header>, IRepositoryHeader
    {
        private readonly RepositoryContext _context;
        public RepositoryHeader(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Header> GetHeader(int id, bool trackchanges) => GenericReadExpression(x => x.HeaderId == id, trackchanges);

    }
}
