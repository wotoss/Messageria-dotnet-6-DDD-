

namespace InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
    //ela será uma classe abstrata, ninguem poderá instância ela, somente herdar
    public abstract class Mensagem
    {
        public DateTime MensagemCriada { get;  set; }
        
        //construtor
        public Mensagem()
        {
        
        }

        public virtual bool MensagemEstaValida()
        {
           throw new NotImplementedException();
        }

      
    }
