using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppliTest.Data.Context
{
    class AppliTestSeed
    {
        private readonly IServiceProvider _services;

        public AppliTestDbContext Context { get; private set; }

        public AppliTestSeed(AppliTestDbContext context, IServiceProvider services)
        {
            Context = context;
            _services = services;
        }

        public virtual async Task Run()
        {
            // faire ici les différents seed
        }
    }
}
