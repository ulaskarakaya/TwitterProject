using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.ApplicationLayer.Models.DTOs;
using TwitterProject.ApplicationLayer.Models.VMs;
using TwitterProject.DomainLayer.Entities.Concrete;

namespace TwitterProject.ApplicationLayer.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<AppUser, LoginDto>().ReverseMap();
            CreateMap<AppUser, ExternalLoginDto>().ReverseMap();
            CreateMap<AppUser, EditProfileDto>().ReverseMap();
            CreateMap<AppUser, ProfileSummaryDto>().ReverseMap();
            CreateMap<Follow, FollowDto>().ReverseMap();
           
            CreateMap<Like, LikeDto>().ReverseMap();
            CreateMap<Tweet, SendTweetDto>().ReverseMap();
            CreateMap<Mention, AddMentionDto>().ReverseMap();
            CreateMap<Mention, MentionDto>().ForMember(x => x.UserName, opt => opt.MapFrom(a => a.AppUser.UserName)).ForMember(x => x.UserImage, opt => opt.MapFrom(a => a.AppUser.ImagePath)).ReverseMap();
        }
    }
}
