using ITI.LinkedIn.Context;
using ITI.LinkedIn.Models;
using ITI.LinkedIn.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Core.SingletonManagers
{
    public class SingletonUserPhotoManager : Repository<UserPhoto, ApplicationDbContext>
    {
        static SingletonUserPhotoManager manager;

        private SingletonUserPhotoManager(ApplicationDbContext context) : base(context)
        {
        }

        public static SingletonUserPhotoManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                return new SingletonUserPhotoManager(context);
            }
            return manager;
        }
    }
}
