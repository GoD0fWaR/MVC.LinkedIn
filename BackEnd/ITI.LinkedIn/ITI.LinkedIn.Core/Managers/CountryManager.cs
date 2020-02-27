using ITI.MVC.Layers.Context;
using ITI.MVC.Layers.Models;
using ITI.MVC.Layers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.Layers.Core.Managers
{
    public class CountryManager : Repository<Country, ApplicationDbContext>, IDisposable
    {
        static CountryManager manager;
        private CountryManager(ApplicationDbContext context) : base(context)
        {
        }

        public static CountryManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new CountryManager(context);
                
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;

        }
    }
}
