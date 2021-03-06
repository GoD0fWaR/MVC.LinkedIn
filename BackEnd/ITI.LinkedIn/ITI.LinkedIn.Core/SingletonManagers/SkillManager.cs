﻿using ITI.LinkedIn.Context;
using ITI.LinkedIn.Models;
using ITI.LinkedIn.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Core.Managers
{
    public class SkillManager : Repository<Skill, ApplicationDbContext>, IDisposable
    {
        static SkillManager manager;

        private SkillManager(ApplicationDbContext context) : base(context)
        {
        }

        public static SkillManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new SkillManager(context);
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;
        }
    }
}
