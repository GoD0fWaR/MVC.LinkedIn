
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
    public class PostManager : Repository<Post, ApplicationDbContext> ,IDisposable
    {
        private static PostManager manager;
        private PostManager(ApplicationDbContext context) : base(context)
        {
        }

        public static PostManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new PostManager(context);
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;
        }
    }
}
