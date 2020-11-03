using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterProject.DomainLayer.Repositories.Abstraction;
using TwitterProject.DomainLayer.UnitofWork.Abstraction;
using TwitterProject.InfrastructureLayer.Context;
using TwitterProject.InfrastructureLayer.Repositories.Concrete;

namespace TwitterProject.InfrastructureLayer.UnitofWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            this._db = applicationDbContext ?? throw new ArgumentNullException("db can't be null");
        }
        private ITweetRepository _tweetRepository;
        public ITweetRepository Tweet { get { return _tweetRepository ?? (_tweetRepository = new TweetRepository(_db)); } }
        private IMentionRepository _mentionRepository;
     
        public IMentionRepository Mention { get { return _mentionRepository ?? (_mentionRepository = new MentionRepository(_db)); } }

        public IAppUserRepository AppUser => throw new NotImplementedException();

        public IFollowRepository Follow => throw new NotImplementedException();

        public ILikeRepository Like => throw new NotImplementedException();

        public IShareRepository Share => throw new NotImplementedException();
        private bool isDisposed = false;
        protected async ValueTask DisposeAsync(bool disposing)
        {
            if (disposing)
            {
                await _db.DisposeAsync();
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (!isDisposed)
            {
                isDisposed = true;
                await DisposeAsync(true);
                GC.SuppressFinalize(this);
            }
        }

        public async Task ExecuteSqlRaw(string sql, params object[] parameters)
        {
            await _db.Database.ExecuteSqlRawAsync(sql, parameters);
        }
        public async Task Commit()
        {
            await _db.SaveChangesAsync();
        }
    }
}
