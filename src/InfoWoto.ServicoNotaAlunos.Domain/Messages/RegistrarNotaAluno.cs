using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
using InfoWoto.ServicoNotaAlunos.Domain.Validations;

namespace InfoWoto.ServicoNotaAlunos.Domain.Messages;

    public class RegistrarNotaAluno : Mensagem
    {
        public int AlunoId { get; set; }

        public int ProfessorId { get; set; }

        public int AtividadeId { get; set; }

        
        
        //CorrelationId => seria o identificador da transação.
        public Guid CorrelationId { get; set; }

        public double ValorNota { get; set; }

        public bool NotaSubstitutiva { get; set; }

        public override bool MensagemEstaValida()
        {
            Validacoes = RegistrarNotaAlunoValidacao.Instance.Validate(this);

            return Validacoes.IsValid;
        }
    }
