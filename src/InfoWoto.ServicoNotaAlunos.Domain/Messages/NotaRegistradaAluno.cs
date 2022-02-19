
using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;

namespace InfoWoto.ServicoNotaAlunos.Domain.Messages;

    public class NotaRegistradaAluno : Mensagem
    {
        //contrutor 
        public NotaRegistradaAluno()
        {
            Erros = new ();
        }

        public int AlunoId { get; set; }

        public int AtividadeId { get; set; }

        public bool PossuiErros { get; set; }

        public Guid CorrelationId { get; set; }
        
        //aqui vai receber uma lista de erros 
        public List<string> Erros { get; set; }
        
        //estou obsecrevendo com override o método => MensagemEstaValida() 
        //que esta na minha base. => neste caso a minha base => seria o que esta herdando :Mensagem
        public override bool MensagemEstaValida()
        {
            return base.MensagemEstaValida();
        }
    }
