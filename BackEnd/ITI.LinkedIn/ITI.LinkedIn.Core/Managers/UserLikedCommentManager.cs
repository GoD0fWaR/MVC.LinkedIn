
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
    public class UserLikedCommentManager : Repository<UserLikedComment, ApplicationDbContext>, IDisposable
    {
        private static UserLikedCommentManager manager;
        private UserLikedCommentManager(ApplicationDbContext context) : base(context)
        {
        }

        public static UserLikedCommentManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new UserLikedCommentManager(context);
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;
        }
    }
}
