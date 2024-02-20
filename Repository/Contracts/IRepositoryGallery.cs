using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryGallery: IRepositoryBase<Gallery>
    {
        IQueryable<Gallery> GetGallery(int id, bool trackchanges);
    }
}
