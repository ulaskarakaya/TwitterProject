using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.DomainLayer.Entities.Abstraction;
using TwitterProject.DomainLayer.Enums;

namespace TwitterProject.DomainLayer.Entities.Concrete
{
    public class Tweet:IBaseEntity
    {
        public Tweet()
        {
            Likes = new List<Like>();
            Shares = new List<Share>();
            Mentions = new List<Mention>();
            
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreateDate { get => DateTime.Now; private set { } }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<Like> Likes { get; set; }
        public List<Share> Shares { get; set; }
        public List<Mention> Mentions { get; set; }
    }
}
