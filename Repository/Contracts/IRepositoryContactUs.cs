using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryContactUs : IRepositoryBase<ContactUs>
    {
        IQueryable<ContactUs> GetContactUs(int id, bool trackchanges);

    }
}
