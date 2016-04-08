using Efa.Domain.Entities;
using Efa.Domain.ValueObjects;

namespace Efa.Domain.Interfaces.Services
{
    public interface IProfessorService : IServiceBase<Professor>
    {
        ValidationResult AdicionarProfessor(Professor professor);

        ValidationResult AtualizarProfessor(Professor professor);
    }
}