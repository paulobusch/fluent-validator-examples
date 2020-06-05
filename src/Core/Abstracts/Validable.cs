using Code.Generics;
using Code.interfaces;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Code.Abstracts
{
    public abstract class Validable<T> : IValidable { 
        private readonly GenericValidator<T> _validator = new GenericValidator<T>();
        public abstract Task<ValidationResult> ValidateAsync();
        protected Task<ValidationResult> ValidateAsync(T obj) => _validator.ValidateAsync(obj);
        protected IRuleBuilderInitial<T, TProperty> RuleFor<TProperty>(Expression<Func<T, TProperty>> expression) => _validator.RuleFor(expression);
    }
}
