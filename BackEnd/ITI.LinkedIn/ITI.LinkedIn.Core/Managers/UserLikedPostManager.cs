
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
    public class UserLikedPostManager : Repository<UserLikedPost, ApplicationDbContext>, IDisposable
    {
        private static UserLikedPostManager manager;
        private UserLikedPostManager(ApplicationDbContext context) : base(context)
        {
        }

        public static UserLikedPostManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new UserLikedPostManager(context);
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;
        }
    }
}
