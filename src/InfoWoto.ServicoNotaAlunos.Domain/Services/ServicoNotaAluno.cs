
using InfoWoto.ServicoNotaAlunos.Domain.Messages;
using InfoWoto.ServicoNotaAlunos.Domain.Interfaces.Services;
using InfoWoto.ServicoNotaAlunos.Domain.Notification;

namespace InfoWoto.ServicoNotaAlunos.Domain.Services;
    //esta classe implementa o contrato do IServicoNotaAluno
    public class ServicoNotaAluno : IServicoNotaAluno
    {
        
        private readonly ContextoNotificacao _contextoNotificacao;
        public ServicoNotaAluno(ContextoNotificacao contextoNotificacao)
        {
            _contextoNotificacao = contextoNotificacao;
        }
        public async Task LancarNota(RegistrarNotaAluno registrarNotaAluno)
        {
            Console.WriteLine("Processando lógica de negocios....");

            if (!registrarNotaAluno.MensagemEstaValida())
            {
                //este é o caminho onde estará nossas mensagens de erro...
                _contextoNotificacao.AddRange(registrarNotaAluno.Validacoes.Errors.Select(x => x.ErrorMessage));
                //caso tenha erro eu Adiciono no contexto (AddRange) e retorno. 
                return;
            }
        }
    }
