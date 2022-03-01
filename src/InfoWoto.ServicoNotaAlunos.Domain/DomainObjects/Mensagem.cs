

using FluentValidation.Results;

namespace InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
    //ela será uma classe abstrata, ninguem poderá instância ela, somente herdar
    public abstract class Mensagem
    {
        public DateTime MensagemCriada { get; protected set; }

        //por esta propriedade ser protected só quem é da classe pode usa-lá.
        public ValidationResult Validacoes {get; protected set;}
        
        //construtor
        public Mensagem()
        {
        
        }

        public virtual bool MensagemEstaValida()
        {
           throw new NotImplementedException();
        }

      
    }
