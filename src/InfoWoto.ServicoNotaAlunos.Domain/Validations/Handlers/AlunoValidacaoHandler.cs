using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
using InfoWoto.ServicoNotaAlunos.Domain.Entidades;
using InfoWoto.ServicoNotaAlunos.Domain.Notification;
using InfoWoto.ServicoNotaAlunos.Domain.Utils;
using InfoWoto.ServicoNotaAlunos.Domain.Validations.Handlers.Base;

namespace InfoWoto.ServicoNotaAlunos.Domain.Validations.Handlers;

    //veja que estou trazendo a minha classe de transporte de dados o dto para dentro de meu =>  AbstractHandler<ServicoNotaValidacaoRequest>
    public class AlunoValidacaoHandler : AbstractHandler<ServicoNotaValidacaoRequest>
    {
        private readonly ContextoNotificacao _contextoNotificacao;

        public AlunoValidacaoHandler(ContextoNotificacao contexto)
        {
            _contextoNotificacao = contexto;
        }

        //para poder sobescrever este método Handle => ele foi passado como (virtual lá no AbstrctHandler)
        public override void Handle(ServicoNotaValidacaoRequest request)
    {
        if (!request.Aluno.Usuario.Ativo)
        {
           _contextoNotificacao.Add(Constantes.MensagensValidacao.ALUNO_INATIVO);
            return;
        }

        /*
        if(!request.Aluno.Ativo)
        {
            _contextoNotificacao.Add(Constantes.MensagensValidacao.ALUNO_INATIVO);
            return;
        }
        */
       
        if (!AlunoEstaMatriculado(request.Aluno, request.Disciplina.Id))
          {
             _contextoNotificacao.Add(Constantes.MensagensValidacao.ALUNO_NAO_ESTA_MATRICULADO);
             return;
          }

            base.Handle(request);
        }

    private bool AlunoEstaMatriculado(Aluno aluno, int disciplinaId) =>
             aluno.AlunosTurmas
            .SelectMany(alunoTurma => alunoTurma.Turmas)
            .Any(turma => turma.DisciplinaId == disciplinaId);

}
