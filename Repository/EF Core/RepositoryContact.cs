using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositoryContact : RepositoryBase<Contact>, IRepositoryContact
    {
        private readonly RepositoryContext _context;
        public RepositoryContact(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Contact> GetContact(int id, bool trackchanges) => GenericReadExpression(x => x.ContactId == id, trackchanges);

    }
}
