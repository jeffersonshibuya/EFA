using Efa.Domain.Interfaces.Specification;
using Efa.Domain.Interfaces.Validation;

namespace Efa.Domain.Validation
{
    public class Regra<TEntity> : IRegra<TEntity> where TEntity : class 
    {
        private readonly ISpecification<TEntity> _specificationRule;
        public string MensagemErro { get; private set; }

        public Regra(ISpecification<TEntity> specificationRule, string mensagemErro)
        {
            this._specificationRule = specificationRule;
            this.MensagemErro = mensagemErro;
        }


        public bool Validar(TEntity entity)
        {
            return this._specificationRule.IsSatisfiedBy(entity);
        }
    }
}