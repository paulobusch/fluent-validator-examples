using Demo.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.FullName).NotEmpty().Length(1, 50)
                .WithMessage($"Parameter {nameof(Person.FullName)} is required");
            
            RuleFor(p => p.Age).NotEmpty()
                .InclusiveBetween(18, 50)
                .WithMessage($"Parameter {nameof(Person.Age)} require between 18 and 50");

            RuleFor(p => p.Discount).NotEmpty()
                .GreaterThan(0)
                .LessThanOrEqualTo(100)
                .When(p => p.HasDiscount)
                .WithMessage($"Paramenter {nameof(Person.Discount)} require between 0 and 100");
        
            RuleFor(p => p.BirthDate).Must(ValidDateOfBirth)
                .WithMessage($"Parameter {nameof(Person.BirthDate)} is invalid");
        }

        public bool ValidDateOfBirth(DateTime date) { 
                return date <= DateTime.Today.AddYears(-18);
        }
    }
}
