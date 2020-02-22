using ITI.LinkedIn.Context;
using ITI.LinkedIn.Models;
using ITI.LinkedIn.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITI.LinkedIn.Core.Managers
{
    public class CommentManager : Repository<Comment, ApplicationDbContext>, IDisposable
    {
        private static CommentManager manager;
        private CommentManager(ApplicationDbContext context) : base(context)
        {
        }

        public static CommentManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new CommentManager(context);
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;
        }

       
    }
}
