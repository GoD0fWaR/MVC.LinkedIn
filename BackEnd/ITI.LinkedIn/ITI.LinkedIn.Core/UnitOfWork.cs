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
        ApplicationDbContext dbContext;

        public UnitOfWork(IOwinContext owinContext)
        {
            dbContext = owinContext.Get<ApplicationDbContext>();
            ApplicationUserManager = owinContext.Get<ApplicationUserManager>();
            ApplicationRoleManager = owinContext.Get<ApplicationRoleManager>();
            ApplicationSignInManager = owinContext.Get<ApplicationSignInManager>();
        }

        public static UnitOfWork Create(IdentityFactoryOptions<UnitOfWork> options, IOwinContext owinContext)
        {
            return new UnitOfWork(owinContext);
        }

        public ApplicationUserManager ApplicationUserManager { get; }
        public ApplicationRoleManager ApplicationRoleManager { get; }
        public ApplicationSignInManager ApplicationSignInManager { get; }

        public PostManager PostManager
        {
            get
            {
                return PostManager.GetInstance(dbContext);
            }

        }

        public PostPhotoManager PostPhotoManager
        {
            get
            {
                return PostPhotoManager.GetInstance(dbContext);
            }

        }
        public CommentManager CommentManager
        {
            get
            {
                return CommentManager.GetInstance(dbContext);
            }

        }
        public CommentPhotoManager CommentPhotoManager
        {
            get
            {
                return CommentPhotoManager.GetInstance(dbContext);
            }

        }
        public ReplyManager ReplyManager
        {
            get
            {
                return ReplyManager.GetInstance(dbContext);
            }

        }
        public UserLikedPostManager UserLikedPostManager
        {
            get
            {
                return UserLikedPostManager.GetInstance(dbContext);
            }

        }
        public UserLikedCommentManager UserLikedCommentManager
        {
            get
            {
                return UserLikedCommentManager.GetInstance(dbContext);
            }

        }
        public UserLikedReplyManager UserLikedReplyManager
        {
            get
            {
                return UserLikedReplyManager.GetInstance(dbContext);
            }

        }

        public void Dispose()
        {
            PostManager.Dispose();
            PostPhotoManager.Dispose();
            CommentManager.Dispose();
            ReplyManager.Dispose();
            UserLikedPostManager.Dispose();
            UserLikedCommentManager.Dispose();
            UserLikedReplyManager.Dispose();
            CommentPhotoManager.Dispose();
            ApplicationRoleManager.Dispose();
            ApplicationSignInManager.Dispose();
            ApplicationUserManager.Dispose();

        }
    }
}
