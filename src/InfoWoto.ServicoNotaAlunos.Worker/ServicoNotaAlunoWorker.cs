
using InfoWoto.ServicoNotaAlunos.Domain.Notification;
using InfoWoto.ServicoNotaAlunos.MessageBus.SQS.Clients;
using InfoWoto.ServicoNotaAlunos.Application.Interfaces;
using InfoWoto.ServicoNotaAlunos.Domain.Utils;

namespace InfoWoto.ServicoNotaAlunos.Worker;

public class ServicoNotaAlunoWorker : BackgroundService
{
    private readonly ILogger<ServicoNotaAlunoWorker> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ServicoNotaAlunoWorker(ILogger<ServicoNotaAlunoWorker> logger,
                                IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        // esta injeção referente a esta classe vem do apnet IServiceScopeFactory
        //esta criando uma fabrica de escopo
        _serviceScopeFactory = serviceScopeFactory; 
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            //veja boa pratica => fiz uma classe Constantes para receber todas as minhas mensagens do sistema 
               //e utilizo ela buscando pela (Classe=>Constantes=> classe statica=>MensagensAplicacao=>Propriedade=>Mensagem=>SEM_MENSAGEM_NA_FILA)
           _logger.LogInformation(Constantes.MensagensAplicacao.INICANDO_SERVICO);
             //esta criando uma fabrica de escopo.
           using var scope = _serviceScopeFactory.CreateScope();
           //aqui eu tenho o serviço de aplicação.
           var servicoNotaAlunoApp = scope.ServiceProvider.GetRequiredService<IServicoAplicacaoNotaAluno>();
           //aqui eu tenho o serviço de mensageria. 
           var clienteMensagens = scope.ServiceProvider.GetRequiredService<ILancarNotaAlunoFakeClient>();
           //aqui eu tenho o serviço de notificação.
           var contextoNotificacao = scope.ServiceProvider.GetRequiredService<ContextoNotificacao>();

           //vai me devolver uma mensagem
           var mensagem = await clienteMensagens.GetMessageAsync();
           
           //estou fazendo a verificação se tem notificação.
           if (contextoNotificacao.TemNotificacoes)
           {
               _logger.LogError(contextoNotificacao.ToJson());
            //este continue vai pular a interração que tem em baixo e vai passar para proxima interração.
               continue;
           }
           if(mensagem is null)
           {
               //veja boa pratica => fiz uma classe Constantes para receber todas as minhas mensagens do sistema 
               //e utilizo ela buscando pela (Classe=>Constantes=> classe statica=>MensagensAplicacao=>Propriedade=>Mensagem=>SEM_MENSAGEM_NA_FILA)
               _logger.LogInformation(Constantes.MensagensAplicacao.SEM_MENSAGEM_NA_FILA);
               continue;
           }

           await servicoNotaAlunoApp.ProcessarLancamentoNota(mensagem.MessageBody);
        }
    }
}
