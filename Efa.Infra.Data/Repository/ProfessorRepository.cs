using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Repository;
using Efa.Infra.Data.Context;

namespace Efa.Infra.Data.Repository
{
    public class ProfessorRepository : RepositoryBase<Professor, EfaContext>, IProfessorRepository
    {    
         
    }
}