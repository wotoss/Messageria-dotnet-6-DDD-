using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
using InfoWoto.ServicoNotaAlunos.Domain.Entidades;
using InfoWoto.ServicoNotaAlunos.Domain.Notification;
using InfoWoto.ServicoNotaAlunos.Domain.Utils;
using InfoWoto.ServicoNotaAlunos.Domain.Validations.Handlers.Base;

namespace InfoWoto.ServicoNotaAlunos.Domain.Validations.Handlers;

    public class DisciplinaValidacaoHandler : AbstractHandler<ServicoNotaValidacaoRequest>
    {
    private readonly ContextoNotificacao _contextoNotificacao;

    public DisciplinaValidacaoHandler(ContextoNotificacao contextoNotificacao)
    {
        _contextoNotificacao = contextoNotificacao;
    }

    public override void Handle(ServicoNotaValidacaoRequest request)
    {
          //A disciplina não pode ser do tipo encontro
         if(request.Disciplina.TipoDisciplina == Enums.TipoDisciplina.Encontro)
         {
             _contextoNotificacao.Add(Constantes.MensagensValidacao.DISCIPLINA_TIPO_ENCONTRO);
             return;
         }

         //a disciplina deve estar ativa.
         if(!DisciplinaAtiva(request.Disciplina))
         {
              _contextoNotificacao.Add(Constantes.MensagensValidacao.DISCIPLINA_INATIVA);
              return;
         }

        base.Handle(request);
    }

      private bool DisciplinaAtiva(Disciplina disciplina) => 
          disciplina.DataInicio <= DateTime.Now && disciplina.DataFim >= DateTime.Now;

}
