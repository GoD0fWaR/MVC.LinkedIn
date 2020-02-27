using ITI.LinkedIn.Context;
using ITI.LinkedIn.Models.PivotModels;
using ITI.LinkedIn.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Core.SingletonManagers
{
    public class SingletonUserConnectionManager : Repository<UserConnection, ApplicationDbContext>
    {
        static SingletonUserConnectionManager manager;

        private SingletonUserConnectionManager(ApplicationDbContext context) : base(context)
        {
        }

        public static SingletonUserConnectionManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new SingletonUserConnectionManager(context);
            }
            return manager;
        }
    }
}
