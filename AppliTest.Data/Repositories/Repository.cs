using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AppliTest.Data.Repositories
{
    public class Repository<TContext, TEntity> : IRepository<TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        
        /// <summary>
        /// Contexte EF
        /// </summary>
        protected TContext Context { get; }

        /// <summary>
        /// DbSet de l'entité <typeparamref name="TEntity"/>
        /// </summary>
        protected virtual DbSet<TEntity> Set => Context.Set<TEntity>();

    }
}
