using System;
using System.Threading;
using System.Net.Http;

namespace InfoWoto.ServicoNotaAlunos.Worker;
    public class WorkerExemplo : IHostedService, IDisposable
    {
        private readonly ILogger<WorkerExemplo> _logger;

        private Timer _timer;

        private readonly HttpClient _client;
        public WorkerExemplo(ILogger<WorkerExemplo> logger)
        {
           _logger = logger;
           _client = new HttpClient();
        }
        public Task StartAsync(CancellationToken stoppingToken)
        {
           _logger.LogInformation("Iniciando serviço....");

           _timer = new Timer(VerificarSite, null, TimeSpan.Zero,
           TimeSpan.FromSeconds(5));

           return Task.CompletedTask;
        }
        
        //ele vai pequisar lá no google => https://www.google.com.br
         private async void VerificarSite(object? state)
        {
           var response = await _client.GetAsync("https://www.google.com.br");
           if(response.IsSuccessStatusCode)
             _logger.LogInformation("O site está Ok!");
           else
            _logger.LogError("O site não está legal!");
        }

        public  Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Parando serviço....");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
           _timer?.Dispose();
        }
    }
