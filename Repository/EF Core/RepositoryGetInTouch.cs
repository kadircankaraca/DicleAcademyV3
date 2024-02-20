using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositoryGetInTouch: RepositoryBase<GetInTouch>, IRepositoryGetInTouch
    {
        private readonly RepositoryContext _context;
        public RepositoryGetInTouch(RepositoryContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<GetInTouch> GetGetInTouch(int id, bool trackchanges) => GenericReadExpression(x => x.GetInTouchId == id, trackchanges);

    }
}
