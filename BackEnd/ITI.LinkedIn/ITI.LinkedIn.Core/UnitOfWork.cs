using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using ITI.LinkedIn.Context;
using ITI.LinkedIn.Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #region Hossam
        public SkillManager SkillManager
        {
            get
            {
                return SkillManager.GetInstance(context);
            }
        }
        public CourseManager CourseManager
        {
            get
            {
                return CourseManager.GetInstance(context);
            }
        }
        public EmploymentTypeManager EmploymentTypeManager
        {
            get
            {
                return EmploymentTypeManager.GetInstance(context);
            }
        }
        public UserPhotoManager UserPhotoManager
        {
            get
            {
                return UserPhotoManager.GetInstance(context);
            }
        }
        public UserConnectionManager UserConnectionManager
        {
            get
            {
                return UserConnectionManager.GetInstance(context);
            }
        }
        #endregion

        #region Nora
        public UserProjectManager UserProjectManager
        {
            get
            {
                return UserProjectManager.GetInstance(context);
            }
        }
        public LanguageManager LanguageManager
        {
            get
            {
                return LanguageManager.GetInstance(context);
            }
        }
        public UserLanguageManager UserLanguageManager
        {
            get
            {
                return UserLanguageManager.GetInstance(context);
            }
        }
        public EducationManager EducationManager
        {
            get
            {
                return EducationManager.GetInstance(context);
            }
        }
        #endregion

        #region Wafaa
        public ExperienceManager ExperienceManager
        {
            get
            {
                return ExperienceManager.GetInstance(context);
            }
        }
        public CountryManager CountryManager
        {
            get
            {
                return CountryManager.GetInstance(context);
            }
        }
        public CompanyManager CompanyManager
        {
            get
            {
                return CompanyManager.GetInstance(context);
            }
        }
        public JobManager JobManager
        {
            get
            {
                return JobManager.GetInstance(context);
            }
        }
        public CertificationManager CertificationManager
        {
            get
            {
                return CertificationManager.GetInstance(context);
            }
        }
        #endregion

        #region Aya
        public PostManager PostManager
        {
            get
            {
                return PostManager.GetInstance(context);
            }
        }
        public CommentManager CommentManager
        {
            get
            {
                return CommentManager.GetInstance(context);
            }
        }
        public ReplyManager ReplyManager
        {
            get
            {
                return ReplyManager.GetInstance(context);
            }
        }
        public PostPhotoManager PostPhotoManager
        {
            get
            {
                return PostPhotoManager.GetInstance(context);
            }
        }
        public CommentPhotoManager CommentPhotoManager
        {
            get
            {
                return CommentPhotoManager.GetInstance(context);
            }
        }
        public ReplyPhotoManager ReplyPhotoManager
        {
            get
            {
                return ReplyPhotoManager.GetInstance(context);
            }
        }
        #endregion

        public ApplicationUserManager ApplicationUserManager { get; }
        public ApplicationRoleManager ApplicationRoleManager { get; }
        public ApplicationSignInManager ApplicationSignInManager { get; }

        public void Dispose()
        {
            #region Hossam
            SkillManager.Dispose();
            CourseManager.Dispose();
            EmploymentTypeManager.Dispose();
            UserPhotoManager.Dispose();
            UserConnectionManager.Dispose();
            #endregion

            #region Nora
            UserProjectManager.Dispose();
            LanguageManager.Dispose();
            UserLanguageManager.Dispose();
            EducationManager.Dispose();
            #endregion

            #region Wafaa
            ExperienceManager.Dispose();
            CountryManager.Dispose();
            CompanyManager.Dispose();
            JobManager.Dispose();
            CertificationManager.Dispose();
            #endregion

            #region Aya
            PostManager.Dispose();
            CommentManager.Dispose();
            ReplyManager.Dispose();
            PostPhotoManager.Dispose();
            CommentPhotoManager.Dispose();
            ReplyPhotoManager.Dispose();
            #endregion

            ApplicationUserManager.Dispose();
            ApplicationRoleManager.Dispose();
            ApplicationSignInManager.Dispose();

            context = null;
        }
    }
}
