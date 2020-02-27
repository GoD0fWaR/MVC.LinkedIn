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
    public class UserProjectManager : Repository<UserProject, ApplicationDbContext>, IDisposable
    {
        static UserProjectManager manager;

        private UserProjectManager(ApplicationDbContext context) : base(context)
        {
        }

        public static UserProjectManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new UserProjectManager(context);
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;
        }
    }
}