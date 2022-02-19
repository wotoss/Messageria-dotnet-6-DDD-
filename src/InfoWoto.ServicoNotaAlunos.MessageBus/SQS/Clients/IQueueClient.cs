using InfoWoto.ServicoNotaAlunos.MessageBus.Messages;

namespace InfoWoto.ServicoNotaAlunos.MessageBus.SQS.Clients;


    //este seria o contrato base IQueueClient
    public interface IQueueClient<T>
    {
        Task SendMessageAsync(T message);

        Task SendMessageAsync(List<T> messageList);

        Task<QueueMessage<T>> GetMessageAsync();

        Task<List<QueueMessage<T>>> GetMessageAsync(int count);

        Task DeleteMessageAsync(string messageHandle);
    }
