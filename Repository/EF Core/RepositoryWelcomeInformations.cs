using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositoryWelcomeInformations: RepositoryBase<WelcomeInformations>, IRepositoryWelcomeInformations
    {
        private readonly RepositoryContext _context;
        public RepositoryWelcomeInformations(RepositoryContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<WelcomeInformations> GetWelcomeInformations(int id, bool trackchanges) => GenericReadExpression(x => x.WelcomeInformationId == id, trackchanges);

    }
}
