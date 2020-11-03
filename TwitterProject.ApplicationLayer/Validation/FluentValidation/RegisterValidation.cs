using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.ApplicationLayer.Models.DTOs;

namespace TwitterProject.ApplicationLayer.Validation.FluentValidation
{
    public class RegisterValidation : AbstractValidator<RegisterDto>
    {
        public RegisterValidation()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Enter a email adress..!").EmailAddress().WithMessage("Please enter valid email adress..!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please enter a password..!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().Equal(x => x.Password).WithMessage("Password don't match..!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name can't be empty..!").MinimumLength(3).MaximumLength(50).WithMessage("Lenght must be between 3 and 50 characters..!");
        }
    }
}
