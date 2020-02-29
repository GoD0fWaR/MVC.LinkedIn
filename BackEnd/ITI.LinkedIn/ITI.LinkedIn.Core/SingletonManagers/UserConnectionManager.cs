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
    public class UserConnectionManager : Repository<UserConnection, ApplicationDbContext>, IDisposable
    {
        static UserConnectionManager manager;

        private UserConnectionManager(ApplicationDbContext context) : base(context)
        {
        }

        public static UserConnectionManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new UserConnectionManager(context);
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;
        }
    }
}
