using AppliTest.Data.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppliTest.Data.Context
{

    public class AppliTestDbContext : DbContext, IAppliTestDbContext
    {

        // Utilisé par l’implémentation de IDesignTimeDbContextFactory
        public AppliTestDbContext(DbContextOptions<AppliTestDbContext> options)
            : base(options)
        {

        }

        public DbSet<Personne> Personnes { get; set; }


        #region DbContext Overrides

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        #endregion
    }

}
