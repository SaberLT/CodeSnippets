using CodeSnippets.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets.Database.Base
{
    public abstract class UnitOfWorkBase<TDbContext> : IUnitOfWork<TDbContext> 
        where TDbContext : DbContext
    {
        private readonly IDbContextFactory<TDbContext> _dbContextFactory;
        
        protected UnitOfWorkBase(IDbContextFactory<TDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public virtual void Commit()
        {
            DbContext.SaveChanges();
        }

        public virtual async Task CommitAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        protected TDbContext DbContext => _dbContextFactory.GetDbContext();
        protected IDbContextFactory<TDbContext> DbContextFactory => _dbContextFactory;
    }
}
