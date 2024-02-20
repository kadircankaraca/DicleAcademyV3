using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        private readonly RepositoryContext _context;
        public RepositoryUser(RepositoryContext context) : base (context)
        {
            _context = context;
        }
        public User GetUser(string id, bool trackChanges) => GenericReadExpression(x => x.Id.Equals(id), trackChanges).SingleOrDefault();

    }
}
