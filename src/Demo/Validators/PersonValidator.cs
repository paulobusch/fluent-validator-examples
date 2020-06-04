using Demo.Models;
using FluentValidation;
using System;

namespace Demo.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.FullName)
                .NotEmpty().WithMessage($"Parameter {nameof(Person.FullName)} is required")
                .Length(1, 50).WithMessage($"Parameter {nameof(Person.FullName)} must be 1 to 50 characters");
            
            RuleFor(p => p.Age)
                .NotEmpty().WithMessage($"Parameter {nameof(Person.Age)} is required")
                .InclusiveBetween(18, 50).WithMessage($"Parameter {nameof(Person.Age)} require between 18 and 50");

            RuleFor(p => p.Discount)
                .NotNull().WithMessage($"Paramenter {nameof(Person.Discount)} is required")
                .GreaterThan(0).WithMessage($"Paramenter {nameof(Person.Discount)} value require 0 minimum")
                .LessThan(100).WithMessage($"Paramenter {nameof(Person.Discount)} value require 100 maximum")
                .When(p => p.HasDiscount ?? false);
        
            RuleFor(p => p.BirthDate).Must(ValidDateOfBirth)
                .WithMessage($"Parameter {nameof(Person.BirthDate)} is invalid");
        }

        public bool ValidDateOfBirth(DateTime? date) { 
                return date <= DateTime.Today.AddYears(-18);
        }
    }
}
