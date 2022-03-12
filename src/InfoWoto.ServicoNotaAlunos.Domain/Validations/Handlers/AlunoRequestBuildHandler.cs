using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
using InfoWoto.ServicoNotaAlunos.Domain.Interfaces.Repositories;
using InfoWoto.ServicoNotaAlunos.Domain.Notification;
using InfoWoto.ServicoNotaAlunos.Domain.Utils;
using InfoWoto.ServicoNotaAlunos.Domain.Validations.Handlers.Base;

namespace InfoWoto.ServicoNotaAlunos.Domain.Validations.Handlers;

    public class AlunoRequestBuildHandler : AbstractAsyncHandler<ServicoNotaValidacaoRequest>
    {
    private readonly ContextoNotificacao _contextoNotificacao;
    private readonly IUsuarioRepository _usuarioRepository;

    public AlunoRequestBuildHandler(ContextoNotificacao contextoNotificacao,
                                    IUsuarioRepository usuarioRepository)
       {
          _contextoNotificacao = contextoNotificacao;
          _usuarioRepository = usuarioRepository;
       }
       public override async Task Handle(ServicoNotaValidacaoRequest request)
       {
            //então vamos lá com as excessões se o aluno vinher nullo => ?? throw new Exception(""); eu não deixo prosseguir
             request.Aluno = await _usuarioRepository.BuscarAluno(request.AlunoId);

            //evitou mandar uma excessão
            if(request.Aluno is null)
            {
               _contextoNotificacao.Add(Constantes.MensagensExcecao.ALUNO_INEXISTENTE);
               return;
            }

           await base.Handle(request);
       }
    }
