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
    public class SingletonSkillManager : Repository<Skill, ApplicationDbContext>, IDisposable
    {
        static SingletonSkillManager manager;

        private SingletonSkillManager(ApplicationDbContext context) : base(context)
        {
        }

        public static SingletonSkillManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new SingletonSkillManager(context);
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;
        }
    }
}
