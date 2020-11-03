using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.DomainLayer.Entities.Concrete;
using TwitterProject.DomainLayer.Repositories.Abstraction;
using TwitterProject.InfrastructureLayer.Context;
using TwitterProject.InfrastructureLayer.Repositories.Concrete.Kernel;

namespace TwitterProject.InfrastructureLayer.Repositories.Concrete
{
    public class TweetRepository:BaseRepository<Tweet>, ITweetRepository
    {
        public TweetRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
