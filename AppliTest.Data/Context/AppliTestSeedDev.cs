using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppliTest.Data.Context
{
    class AppliTestSeedDev : AppliTestSeed
    {

        private readonly IServiceProvider _services;

        public AppliTestSeedDev(AppliTestDbContext Context, IServiceProvider services)
            : base(Context, services)
        {
            _services = services;
        }

        public override async Task Run()
        {
            await base.Run();

            //Seed spécifique au dev

        }

    }
}
