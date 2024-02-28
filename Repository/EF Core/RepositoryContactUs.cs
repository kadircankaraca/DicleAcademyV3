using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositoryContactUs : RepositoryBase<ContactUs>, IRepositoryContactUs
    {
        private readonly RepositoryContext _context;
        public RepositoryContactUs(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ContactUs> GetContactUs(int id, bool trackchanges) => GenericReadExpression(x => x.ContactUsId == id, trackchanges);

    }
}
