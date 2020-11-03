using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.DomainLayer.Enums;

namespace TwitterProject.DomainLayer.Entities.Abstraction
{
    public interface IBaseEntity
    {
        public DateTime CreateDate { get;  }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
    }
}
