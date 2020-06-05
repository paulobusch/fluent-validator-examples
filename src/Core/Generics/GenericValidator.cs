using FluentValidation;

namespace Code.Generics
{
    internal class GenericValidator<T> : AbstractValidator<T> where T : class { }
}
