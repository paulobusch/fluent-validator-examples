using System;
using System.Collections.Generic;
using Demo.Models;
using Demo.Validators;
using FluentValidation;
using UnitTests.Utils;
using Xunit;

namespace UnitTests
{
    public class PersonTests
    {
        private readonly IValidator<Person> _validator;

        public PersonTests()
        {
            _validator = new PersonValidator();
        }

        public static IEnumerable<object[]> ValidatorData()
        {
            yield return new object[] { false, nameof(Person.FullName), new Person() };
            yield return new object[] { false, nameof(Person.FullName), new Person(fullName: string.Empty) };
            yield return new object[] { false, nameof(Person.FullName), new Person(fullName: RandomString.NewSring(51)) };
            yield return new object[] { true , nameof(Person.FullName), new Person(fullName: RandomString.NewSring(50)) };
            yield return new object[] { false, nameof(Person.Age), new Person() };
            yield return new object[] { false, nameof(Person.Age), new Person(age: 17) };
            yield return new object[] { true , nameof(Person.Age), new Person(age: 18) };
            yield return new object[] { false, nameof(Person.Age), new Person(age: 51) };
            yield return new object[] { true , nameof(Person.Age), new Person(age: 50) };
            yield return new object[] { true,  nameof(Person.Discount), new Person() };
            yield return new object[] { true,  nameof(Person.Discount), new Person(discount: -1) };
            yield return new object[] { false, nameof(Person.Discount), new Person(discount: 0, hasDiscount: true) };
            yield return new object[] { true , nameof(Person.Discount), new Person(discount: 1, hasDiscount: true) };
            yield return new object[] { false, nameof(Person.Discount), new Person(discount: 101, hasDiscount: true) };
            yield return new object[] { false, nameof(Person.Discount), new Person(discount: 100, hasDiscount: true) };
            yield return new object[] { true , nameof(Person.Discount), new Person(discount: 99, hasDiscount: true) };
            yield return new object[] { false, nameof(Person.BirthDate), new Person() };
            yield return new object[] { false, nameof(Person.BirthDate), new Person(birthDate: DateTime.Today) };
            yield return new object[] { false, nameof(Person.BirthDate), new Person(birthDate: DateTime.Today.AddYears(-17)) };
            yield return new object[] { true , nameof(Person.BirthDate), new Person(birthDate: DateTime.Today.AddYears(-19)) };
        }

        [Theory]
        [MemberData(nameof(ValidatorData))]
        public void Validator(
            bool isValidField,
            string field,
            Person person
        ) {
            var validateResult = _validator.Validate(person);
            if (isValidField) Assert.DoesNotContain(validateResult.Errors, err => err.ErrorMessage.Contains(field));
            else Assert.Contains(validateResult.Errors, err => err.ErrorMessage.Contains(field));
        }
    }
}
