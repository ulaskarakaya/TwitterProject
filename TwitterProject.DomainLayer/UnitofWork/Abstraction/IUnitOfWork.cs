using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterProject.DomainLayer.Repositories.Abstraction;

namespace TwitterProject.DomainLayer.UnitofWork.Abstraction
{
    public interface IUnitOfWork: IAsyncDisposable
    {
        ITweetRepository Tweet { get; }
        IMentionRepository Mention { get; }
        IAppUserRepository AppUser { get; }
        IFollowRepository Follow { get; }
        ILikeRepository Like { get; }
        IShareRepository Share { get; }
        Task ExecuteSqlRaw(string sql, params object[] parameters);
        Task Commit();
    }
}
