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
    public class LanguageManager : Repository<Language, ApplicationDbContext>, IDisposable
    {
        static LanguageManager manager;
        private LanguageManager(ApplicationDbContext context) : base(context)
        {
        }

        public static LanguageManager GetInstance(ApplicationDbContext Context)
        {
            if (manager == null)
            {
                manager = new LanguageManager(Context);
            }
            return manager;
        }
        public void Dispose()
        {
            manager = null;
        }
    }
}
