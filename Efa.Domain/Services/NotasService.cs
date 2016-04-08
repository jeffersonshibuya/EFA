using System;
using Efa.Domain.Entities;
using Efa.Domain.Interfaces.Repository;
using Efa.Domain.Interfaces.Services;

namespace Efa.Domain.Services
{
    public class NotasService : ServiceBase<Notas>, INotasService
    {
          private readonly INotasRepository _notasRepository;

        public NotasService(INotasRepository notasRepository) : base(notasRepository)
        {
            _notasRepository = notasRepository;
        }

        //public Notas GetByAluno(Guid id)
        //{
        //    return _notasRepository.GetByAluno(id);
        //}
    }
}