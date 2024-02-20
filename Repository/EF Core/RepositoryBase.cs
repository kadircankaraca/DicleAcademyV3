using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly RepositoryContext _context;
        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }
        public void GenericCreate(T entity) => _context.Set<T>().Add(entity);

        public void GenericDelete(T entity) => _context.Set<T>().Remove(entity);
        public IEnumerable<T> GenericRead(bool trackChanges) => _context.Set<T>().AsNoTracking();

        public IQueryable<T> GenericReadExpression(Expression<Func<T, bool>> expression, bool trackChanges) =>
       !trackChanges ? _context.Set<T>().Where(expression).AsNoTracking()
            : _context.Set<T>().Where(expression);

        public void GenericUpdate(T entity) => _context.Set<T>().Update(entity);

    }
}

