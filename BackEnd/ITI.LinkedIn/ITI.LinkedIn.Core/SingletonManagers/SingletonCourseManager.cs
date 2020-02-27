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
    public class SingletonCourseManager : Repository<Course, ApplicationDbContext>, IDisposable
    {
        static SingletonCourseManager manager;

        private SingletonCourseManager(ApplicationDbContext context) : base(context)
        {
        }

        public static SingletonCourseManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new SingletonCourseManager(context);
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;
        }
    }
}
