using Efa.Domain.ValueObjects;

namespace Efa.Domain.Interfaces.Validation
{
    public interface ISelfValidation
    {
        ValidationResult ResultadoValidacao { get; }
        bool IsValid(); 
    }
}