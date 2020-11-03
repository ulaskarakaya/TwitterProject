using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.ApplicationLayer.Models.DTOs;

namespace TwitterProject.ApplicationLayer.Validation.FluentValidation
{
    public class LoginValidation : AbstractValidator<LoginDto>
    {
        public LoginValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Enter a username..!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please enter a password..!");
        }
    }
}
