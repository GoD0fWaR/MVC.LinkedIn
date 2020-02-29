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
    public class UserPhotoManager : Repository<UserPhoto, ApplicationDbContext>, IDisposable
    {
        static UserPhotoManager manager;

        private UserPhotoManager(ApplicationDbContext context) : base(context)
        {
        }

        public static UserPhotoManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new UserPhotoManager(context);
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;
        }
    }
}
