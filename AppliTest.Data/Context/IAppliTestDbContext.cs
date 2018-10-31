using AppliTest.Data.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppliTest.Data.Context
{

    interface IAppliTestDbContext
    {

        DbSet<Personne> Personnes { get; }

    }

}
