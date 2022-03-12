using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
using InfoWoto.ServicoNotaAlunos.Domain.Notification;
using InfoWoto.ServicoNotaAlunos.Domain.Utils;
using InfoWoto.ServicoNotaAlunos.Domain.Validations.Handlers.Base;

namespace InfoWoto.ServicoNotaAlunos.Domain.Validations.Handlers;

    public class ProfessorValidacaoHandler : AbstractHandler<ServicoNotaValidacaoRequest>
    {
        private readonly ContextoNotificacao _contextoNotificacao;
        public ProfessorValidacaoHandler(ContextoNotificacao contextoNotificacao)
        {
             _contextoNotificacao = contextoNotificacao;
        }

        public override void Handle(ServicoNotaValidacaoRequest request)
        {
              if(!request.Professor.Usuario.Ativo)
                 {
                    _contextoNotificacao.Add(Constantes.MensagensValidacao.PROFESSOR_INATIVO);
                    return;
                 }
         
         //Professor deve ministrar a disciplina
              if(!(request.Professor.DisciplinaId == request.Disciplina.Id))
                  {
                     _contextoNotificacao.Add(Constantes.MensagensValidacao.PROFESSOR_NAO_MINISTRA_A_DISCIPLINA);
                      return;
                  }

         //deve ser um professor titular e não suplente.
                if(!request.Professor.ProfessorTitular && request.Professor.ProfessorSuplente)
                   {
                     _contextoNotificacao.Add(Constantes.MensagensValidacao.PROFESSOR_DEVE_SER_TITULAR);
                      return;
                   }

                base.Handle(request);
        }
    }
