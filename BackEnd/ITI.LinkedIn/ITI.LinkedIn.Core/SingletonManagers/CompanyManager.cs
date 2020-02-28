using ITI.LinkedIn.Context;
using ITI.LinkedIn.Models;
using ITI.LinkedIn.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Core.Managers
{
    public class CompanyManager : Repository<Company, ApplicationDbContext>, IDisposable
    {
        static CompanyManager manager;

        private CompanyManager(ApplicationDbContext context) : base(context)
        {
        }

        public static CompanyManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new CompanyManager(context);
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;
        }
    }
}