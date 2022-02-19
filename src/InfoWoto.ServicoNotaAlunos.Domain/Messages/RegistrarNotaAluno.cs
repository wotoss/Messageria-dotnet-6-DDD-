using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;

namespace InfoWoto.ServicoNotaAlunos.Domain.Messages;

    public class RegistrarNotaAluno : Mensagem
    {
        public int AlunoId { get; set; }

        public int ProfessorId { get; set; }

        public int AtividadeId { get; set; }

        public Guid MessageId { get; set; }
        
        //CorrelationId => seria o identificador da transação.
        public Guid CorrelationId { get; set; }

        public double ValorNota { get; set; }

        public bool NotaSubstitutiva { get; set; }

        public override bool MensagemEstaValida()
        {
            return base.MensagemEstaValida();
        }
    }
