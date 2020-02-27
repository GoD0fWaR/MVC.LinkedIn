using ITI.LinkedIn.Context;
using ITI.LinkedIn.Models.PivotModels;
using ITI.LinkedIn.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Core.SingletonManagers
{
    public class UserLanguageManager : Repository<UserLanguage, ApplicationDbContext>, IDisposable
    {
        static UserLanguageManager manager;

        private UserLanguageManager(ApplicationDbContext context) : base(context)
        {
        }

        public static UserLanguageManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new UserLanguageManager(context);
            }
            return manager;
        }

        public void Dispose()
        {
            manager = null;
        }
    }
}
