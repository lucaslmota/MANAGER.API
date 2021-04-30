

using System.Collections.Generic;

namespace Manager.Domain.Entities
{
    public abstract class Base
    {
        public long Id { get; set; }

        //Só pode ser visto aqio dentro
        internal List<string> _errors;

        //O usuário só vai poder ler os erros
        public IReadOnlyCollection<string> Errors => _errors;

        public abstract bool Validate(); 

    }
}