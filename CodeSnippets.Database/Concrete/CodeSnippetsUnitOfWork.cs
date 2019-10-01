using CodeSnippets.Database.Base;
using CodeSnippets.Database.Concrete.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Database.Concrete
{
    public class CodeSnippetsUnitOfWork : UnitOfWorkBase<CodeSnippetsDbContext>, ICodeSnippetsUnitOfWork
    {
        public CodeSnippetsUnitOfWork(ICodeSnippetsDbContextFactory dbContextFactory) : base(dbContextFactory)
        {

        }
    }
}
