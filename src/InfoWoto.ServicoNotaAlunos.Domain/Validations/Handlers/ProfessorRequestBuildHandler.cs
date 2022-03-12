using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
using InfoWoto.ServicoNotaAlunos.Domain.Interfaces.Repositories;
using InfoWoto.ServicoNotaAlunos.Domain.Notification;
using InfoWoto.ServicoNotaAlunos.Domain.Utils;
using InfoWoto.ServicoNotaAlunos.Domain.Validations.Handlers.Base;

namespace InfoWoto.ServicoNotaAlunos.Domain.Validations.Handlers;

    public class ProfessorRequestBuildHandler : AbstractAsyncHandler<ServicoNotaValidacaoRequest>
    {
     //injeção de dependencia   
    private readonly ContextoNotificacao _contextoNotificacao;
    private readonly IUsuarioRepository _usuarioRepository;
    
    //construtor
    public ProfessorRequestBuildHandler(ContextoNotificacao contextoNotificacao,
                                    IUsuarioRepository usuarioRepository)
       {
          _contextoNotificacao = contextoNotificacao;
          _usuarioRepository = usuarioRepository;
       }
    public override async Task Handle(ServicoNotaValidacaoRequest request)
       {
            //então vamos lá com as excessões se o aluno vinher nullo => ?? throw new Exception(""); eu não deixo prosseguir
          //se ele chegou até aqui o aluno existe. então vou devolver o aluno no return
        request.Professor = await _usuarioRepository.BuscarProfessor(request.ProfessorId);
        if(request.Professor is null)
        {
            _contextoNotificacao.Add(Constantes.MensagensExcecao.PROFESSOR_INEXISTENTE);
            return;
        }
        await base.Handle(request);
    }
  }

