using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
using InfoWoto.ServicoNotaAlunos.Domain.Interfaces.Repositories;
using InfoWoto.ServicoNotaAlunos.Domain.Notification;
using InfoWoto.ServicoNotaAlunos.Domain.Utils;
using InfoWoto.ServicoNotaAlunos.Domain.Validations.Handlers.Base;

namespace InfoWoto.ServicoNotaAlunos.Domain.Validations.Handlers;

    public class DisciplinaRequestBuildHandler : AbstractAsyncHandler<ServicoNotaValidacaoRequest>
    {
           //injeção de dependencia   
    private readonly ContextoNotificacao _contextoNotificacao;
    private readonly IDisciplinaRepository _disciplinaRepository;
    
    //construtor
    public DisciplinaRequestBuildHandler(ContextoNotificacao contextoNotificacao,
                                    IDisciplinaRepository disciplinaRepository)
       {
          _contextoNotificacao = contextoNotificacao;
          _disciplinaRepository = disciplinaRepository;
       }
    public override async Task Handle(ServicoNotaValidacaoRequest request)
       {
            //então vamos lá com as excessões se o aluno vinher nullo => ?? throw new Exception(""); eu não deixo prosseguir
          //se ele chegou até aqui o aluno existe. então vou devolver o aluno no return
        request.Disciplina = await _disciplinaRepository.BuscarDisciplinaPorAtividadeId(request.AtividadeId);
        if(request.Professor is null)
        {
            _contextoNotificacao.Add(Constantes.MensagensExcecao.PROFESSOR_INEXISTENTE);
            return;
        }
        await base.Handle(request);
    }
        
}
