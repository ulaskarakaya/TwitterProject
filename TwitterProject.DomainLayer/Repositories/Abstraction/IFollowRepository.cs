using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.DomainLayer.Entities.Concrete;
using TwitterProject.DomainLayer.Repositories.Abstraction.Kernel;

namespace TwitterProject.DomainLayer.Repositories.Abstraction
{
    public interface IFollowRepository:IBaseRepository<Follow>
    {
    }
}
