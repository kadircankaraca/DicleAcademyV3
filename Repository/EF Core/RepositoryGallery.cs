using Entities.Models;
using Repositories.Contracts;
using Repositories.EF_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositoryGallery: RepositoryBase<Gallery>, IRepositoryGallery
    {
        private readonly RepositoryContext _context;
        public RepositoryGallery(RepositoryContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<Gallery> GetGallery(int id, bool trackchanges) => GenericReadExpression(x => x.GalleryId == id, trackchanges);
    }
}
