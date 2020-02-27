using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using ITI.LinkedIn.Context;
using ITI.LinkedIn.Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.LinkedIn.Core.SingletonManagers;

namespace ITI.LinkedIn.Core
{
    public class UnitOfWork : IDisposable
    {
        ApplicationDbContext context;

        public UnitOfWork(IOwinContext owinContext)
        {
            context = owinContext.Get<ApplicationDbContext>();
            ApplicationUserManager = owinContext.Get<ApplicationUserManager>();
            ApplicationRoleManager = owinContext.Get<ApplicationRoleManager>();
            ApplicationSignInManager = owinContext.Get<ApplicationSignInManager>();
        }

        public static UnitOfWork Create(IdentityFactoryOptions<UnitOfWork> options, IOwinContext owinContext)
        {
            return new UnitOfWork(owinContext);
        }

        public SingletonSkillManager SkillManager
        {
            get
            {
                return SingletonSkillManager.GetInstance(context);
            }
        }
        public SingletonCourseManager CourseManager
        {
            get
            {
                return SingletonCourseManager.GetInstance(context);
            }
        }
        public SingletonEmploymentTypeManager EmploymentTypeManager
        {
            get
            {
                return SingletonEmploymentTypeManager.GetInstance(context);
            }
        }
        public SingletonUserPhotoManager UserPhotoManager
        {
            get
            {
                return SingletonUserPhotoManager.GetInstance(context);
            }
        }
        public SingletonUserConnectionManager UserConnectionManager
        {
            get
            {
                return SingletonUserConnectionManager.GetInstance(context);
            }
        }

        public ApplicationUserManager ApplicationUserManager { get; }
        public ApplicationRoleManager ApplicationRoleManager { get; }
        public ApplicationSignInManager ApplicationSignInManager { get; }

        public void Dispose()
        {
            context = null;
        }
    }
}
