using InfoWoto.ServicoNotaAlunos.Worker;
using InfoWoto.ServicoNotaAlunos.IOC;

IHost host = Host.CreateDefaultBuilder(args)
    //configurar as variaveis de ambiente => que esta no launchSettings.json da camada .worker
    //tambem esta carregando o appsettings.Development.json
    .ConfigureAppConfiguration((hostContext, config) =>
    {
        config.AddEnvironmentVariables();
    })
    .ConfigureServices(services =>
    {
        services.ConfigurarInjecaoDependencia()
                 .AddHostedService<ServicoNotaAlunoWorker>();
                //.AddHostedService<WorkerExemplo>();
    })
    .Build();

await host.RunAsync();
