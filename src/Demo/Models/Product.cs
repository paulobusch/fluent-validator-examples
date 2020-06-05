using Code.Abstracts;
using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class Product : Validable<Product> {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        protected Product() {
            RuleFor(r => r.Id)
                .NotEmpty().WithMessage($"Parameter {nameof(Id)} cannot be null");
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage($"Parameter {nameof(Name)} cannot be null");
        }

        public Product(
            string id,
            string name,
            decimal price
        ) : this() { 
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }

        public override Task<ValidationResult> ValidateAsync() => ValidateAsync(this);
    }
}
