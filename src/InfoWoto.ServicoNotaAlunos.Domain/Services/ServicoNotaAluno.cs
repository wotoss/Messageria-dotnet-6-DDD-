
using InfoWoto.ServicoNotaAlunos.Domain.Messages;
using InfoWoto.ServicoNotaAlunos.Domain.Interfaces.Services;
using InfoWoto.ServicoNotaAlunos.Domain.Notification;
using InfoWoto.ServicoNotaAlunos.Domain.Interfaces.Repositories;

namespace InfoWoto.ServicoNotaAlunos.Domain.Services;
    //esta classe implementa o contrato do IServicoNotaAluno
    public class ServicoNotaAluno : IServicoNotaAluno
    {
        
        private readonly ContextoNotificacao _contextoNotificacao;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;
    public ServicoNotaAluno(ContextoNotificacao contextoNotificacao,
                           IUsuarioRepository usuarioRepository, 
                           IDisciplinaRepository disciplinaRepository)
    {
        _contextoNotificacao = contextoNotificacao;
        _usuarioRepository = usuarioRepository;
        _disciplinaRepository = disciplinaRepository;
    }
    public async Task LancarNota(RegistrarNotaAluno registrarNotaAluno)
        {
            Console.WriteLine("Processando lógica de negocios....");

            if (!registrarNotaAluno.MensagemEstaValida())
            {
                //chamando o método que adiciona as mensagens de erro
                AdicionarMensagemErroNoContexto(registrarNotaAluno);
                //caso tenha erro eu Adiciono no contexto (AddRange) e retorno. 
                return;
            }

            var aluno = await _usuarioRepository.BuscarAluno(registrarNotaAluno.AlunoId);
            var professor = await _usuarioRepository.BuscarProfessor(registrarNotaAluno.ProfessorId);
            var disciplina = await _disciplinaRepository.BuscarDisciplinaPorAtividade(registrarNotaAluno.AtividadeId);
        }
      
        //este 
        private void AdicionarMensagemErroNoContexto(RegistrarNotaAluno registrarNotaAluno)
        {
             //este é o caminho onde estará nossas mensagens de erro...
             //ele adiciona estas mensagens de erro no _contextoNotificacao
             _contextoNotificacao.AddRange(registrarNotaAluno.Validacoes.Errors.Select(x => x.ErrorMessage));
        }
    }
