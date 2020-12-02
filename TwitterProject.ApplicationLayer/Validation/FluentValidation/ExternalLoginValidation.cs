using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.ApplicationLayer.Models.DTOs;

namespace TwitterProject.ApplicationLayer.Validation.FluentValidation
{
    public class ExternalLoginValidation : AbstractValidator<ExternalLoginDto>
    {
        public ExternalLoginValidation()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Enter a email address..!").EmailAddress().WithMessage("Please type in to valid email address..!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please type into your name");
        }
    }
}
