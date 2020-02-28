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
    public class CourseManager : Repository<Course, ApplicationDbContext>, IDisposable
    {
        static CourseManager manager;

        private CourseManager(ApplicationDbContext context) : base(context)
        {
        }

        public static CourseManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new CourseManager(context);
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;
        }
    }
}
