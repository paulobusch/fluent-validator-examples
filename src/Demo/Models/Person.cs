using Code.Abstracts;
using FluentValidation;
using System;

namespace Demo.Models
{
    public class Person : Validable<Person> {
        public string FullName { get; private set; }
        public int? Age { get; private set; }
        public string Email { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public bool? HasDiscount { get; private set; }
        public decimal? Discount { get; private set; }

        public Person() {
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

        public Person(
            string fullName = null,
            int? age = null,
            string email = null,
            DateTime? birthDate = null,
            bool? hasDiscount = null,
            decimal? discount = null
        ) : this()
        {
            this.FullName = fullName;
            this.Age = age;
            this.Email = email;
            this.BirthDate = birthDate;
            this.HasDiscount = hasDiscount;
            this.Discount = discount;
        }

        private bool ValidDateOfBirth(DateTime? date)
        {
            return date <= DateTime.Today.AddYears(-18);
        }
    }
}
