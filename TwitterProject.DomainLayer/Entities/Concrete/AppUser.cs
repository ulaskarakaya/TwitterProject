using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TwitterProject.DomainLayer.Entities.Abstraction;
using TwitterProject.DomainLayer.Enums;

namespace TwitterProject.DomainLayer.Entities.Concrete
{
    public class AppUser: IdentityUser<int>, IBaseEntity
    {
        public AppUser()
        {
            Tweets = new List<Tweet>();
            Shares = new List<Share>();
            Likes = new List<Like>();
            Followers = new List<Follow>();
            Following = new List<Follow>();
            Mentions = new List<Mention>();
        }
        public DateTime CreateDate { get => DateTime.Now; private set { } }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
        public string Name { get; set; }
        public string ImagePath { get; set; } = "/images/users/default.jpg";
        public List<Tweet> Tweets { get; set; }
        public List<Like> Likes { get; set; }
        public List<Share> Shares { get; set; }
        public List<Mention> Mentions { get; set; }
        [InverseProperty("Follower")]
        public List<Follow> Followers { get; set; }
        [InverseProperty("Following")]
        public List<Follow> Following { get; set; }
    }
}
