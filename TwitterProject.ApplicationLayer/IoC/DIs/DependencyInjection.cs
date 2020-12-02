using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.ApplicationLayer.AutoMapper;
using TwitterProject.ApplicationLayer.Services.Abstraction;
using TwitterProject.ApplicationLayer.Services.Concrete;
using TwitterProject.DomainLayer.Entities.Concrete;
using TwitterProject.DomainLayer.UnitofWork.Abstraction;
using TwitterProject.InfrastructureLayer.Context;
using TwitterProject.InfrastructureLayer.UnitofWork.Concrete;

namespace TwitterProject.ApplicationLayer.IoC.DIs
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Mapping));

        

            services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.SignIn.RequireConfirmedPhoneNumber = false;
                x.SignIn.RequireConfirmedAccount = false;
                x.SignIn.RequireConfirmedEmail = false;
                x.User.RequireUniqueEmail = true;
                x.Password.RequiredLength = 1;
                x.Password.RequiredUniqueChars = 0;
                x.Password.RequireUppercase = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
