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
    public class UserLikedReplyManager : Repository<UserLikedReply, ApplicationDbContext>, IDisposable
    {
        private static UserLikedReplyManager manager;
        private UserLikedReplyManager(ApplicationDbContext context) : base(context)
        {
        }

        public static UserLikedReplyManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new UserLikedReplyManager(context);
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;
        }
    }
}
