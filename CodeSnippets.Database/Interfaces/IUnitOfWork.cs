using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets.Database.Interfaces
{
    public interface IUnitOfWork<out TDbContext> where TDbContext : DbContext
    {
        void Commit();
        Task CommitAsync();
    }
}
