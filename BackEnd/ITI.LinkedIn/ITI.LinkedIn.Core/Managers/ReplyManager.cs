
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
    public class ReplyManager : Repository<Reply, ApplicationDbContext>, IDisposable
    {
        private static ReplyManager manager;
        private ReplyManager(ApplicationDbContext context) : base(context)
        {
        }

        public static ReplyManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new ReplyManager(context);
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;
        }
    }
}
