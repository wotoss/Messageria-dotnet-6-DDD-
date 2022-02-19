
using InfoWoto.ServicoNotaAlunos.Domain.Messages;
namespace InfoWoto.ServicoNotaAlunos.MessageBus.SQS.Clients;

    public interface ILancarNotaAlunoFakeClient : IQueueClient<RegistrarNotaAluno>
    {
         
    }
