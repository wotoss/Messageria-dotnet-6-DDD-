using Microsoft.Extensions.DependencyInjection;
using InfoWoto.ServicoNotaAlunos.Application.Interfaces;
using InfoWoto.ServicoNotaAlunos.Application.Services;
using InfoWoto.ServicoNotaAlunos.Domain.Interfaces.Services;
using InfoWoto.ServicoNotaAlunos.Domain.Interfaces.Repositories;
using InfoWoto.ServicoNotaAlunos.Data.Repositories;
using InfoWoto.ServicoNotaAlunos.MessageBus.SQS.Clients;
using InfoWoto.ServicoNotaAlunos.Domain.Services;
using InfoWoto.ServicoNotaAlunos.Domain.Notification;
using InfoWoto.ServicoNotaAlunos.Data.Context;

namespace InfoWoto.ServicoNotaAlunos.IOC;

    //esta é a classe deinicialização do nosso registro do contexto de depedencia
    //é uma classe BootStrapper de versão de controller. E quem vai utilizar ela é a program
    
    public static class BootStrapper
    {
        public static IServiceCollection ConfigurarInjecaoDependencia(this IServiceCollection services)
        {
            //aqui eu chamo os métodos criados
            RegistrarServicos(services);
            RegistrarContexto(services);
            RegistrarRepositorios(services);
            RegistrarFilas(services);
            RegistrarContextoNotificacao(services);
            return services;
        }

        private static void RegistrarServicos(IServiceCollection services)
        {
            //estamos registrando o serviço de (Aplicação)
            services.AddScoped<IServicoAplicacaoNotaAluno, ServicoAplicacaoNotaAluno>();
            //estamos registrando o serviço ou camada de (Dominio)
            services.AddScoped<IServicoNotaAluno, ServicoNotaAluno>();
        }

        private static void RegistrarContexto(IServiceCollection services) =>
        services.AddScoped<FakeDbContexto>();
        //{
         //   services.AddScoped<FakeDbContexto>();
        //}

        private static void RegistrarRepositorios(IServiceCollection services)
        {
            //vamos registrar o nosso serviço de (Repositorio)
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            
        }
        //SQS => consumo e envio de mensagem.

        private static void RegistrarFilas(IServiceCollection services)
        {
            services.AddScoped<ILancarNotaAlunoFakeClient, LancarNotaAlunoFakeClient>();
        }

        private static void RegistrarContextoNotificacao(IServiceCollection services)
        {
            //neste caso ele não vai ter interface, ele será a propria classe.
            services.AddScoped<ContextoNotificacao>();
        }
    }
