using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.DomainLayer.Entities.Abstraction;
using TwitterProject.DomainLayer.Enums;

namespace TwitterProject.DomainLayer.Entities.Concrete
{
    public class AppRole:IdentityRole<int>, IBaseEntity
    {
        public DateTime CreateDate { get => DateTime.Now; private set { } }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
    }
}
