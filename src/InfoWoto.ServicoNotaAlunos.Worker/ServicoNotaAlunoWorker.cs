
using InfoWoto.ServicoNotaAlunos.Domain.Notification;
using InfoWoto.ServicoNotaAlunos.MessageBus.SQS.Clients;
using InfoWoto.ServicoNotaAlunos.Application.Interfaces;
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
           _logger.LogInformation("Iniciando o serviço de notas");
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
               _logger.LogInformation("Não possuem mensagens a ser processadas na fila..");
               continue;
           }

           await servicoNotaAlunoApp.ProcessarLancamentoNota(mensagem.MessageBody);
        }
    }
}
