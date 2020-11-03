using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.DomainLayer.Entities.Concrete;
using TwitterProject.DomainLayer.Repositories.Abstraction;
using TwitterProject.InfrastructureLayer.Context;
using TwitterProject.InfrastructureLayer.Repositories.Concrete.Kernel;

namespace TwitterProject.InfrastructureLayer.Repositories.Concrete
{
    public class MentionRepository:BaseRepository<Mention>, IMentionRepository
    {
        public MentionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
