using Microsoft.EntityFrameworkCore;
using System;

namespace Interview.BusinessLogic.Common
{
    internal sealed class UnitOfWork : IDisposable
    {
        private readonly ContextFactory _factory;
        private readonly DbContext _context;

        public UnitOfWork(ContextFactory factory)
        {
            _factory = factory;
            _context = factory.CreateContext();
        }

        public T Get<T>(long id) where T : Entity => _context.Find<T>(id);

        public void Add<T>(T entity) where T : Entity => _context.Set<T>().Add(entity);

        public void Commit() => _context.SaveChanges();

        public void Dispose() => _context?.Dispose();
    }
}
