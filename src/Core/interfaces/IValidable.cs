using FluentValidation.Results;
using System.Threading.Tasks;

namespace Code.interfaces
{
    public interface IValidable {
        ValidationResult Validate();
        Task<ValidationResult> ValidateAsync();
    }
}
