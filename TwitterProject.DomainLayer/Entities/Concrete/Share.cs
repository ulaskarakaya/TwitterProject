using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.DomainLayer.Entities.Abstraction;
using TwitterProject.DomainLayer.Enums;

namespace TwitterProject.DomainLayer.Entities.Concrete
{
    public class Share:IBaseEntity
    {
        public DateTime CreateDate { get => DateTime.Now; private set { } }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }

        public int TweetId { get; set; }
        public Tweet Tweet { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
