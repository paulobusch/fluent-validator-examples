using Code.Generics;
using Code.interfaces;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Code.Abstracts
{
    public abstract class Validable<T> : IValidable where T : class { 
        private readonly GenericValidator<T> _validator = new GenericValidator<T>();
        public ValidationResult Validate() => _validator.Validate(this as T);
        public Task<ValidationResult> ValidateAsync() => _validator.ValidateAsync(this as T);
        protected IRuleBuilderInitial<T, TProperty> RuleFor<TProperty>(Expression<Func<T, TProperty>> expression) => _validator.RuleFor(expression);
    }
}
