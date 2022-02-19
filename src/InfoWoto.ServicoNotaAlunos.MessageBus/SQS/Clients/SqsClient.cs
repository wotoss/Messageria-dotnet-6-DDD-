using  InfoWoto.ServicoNotaAlunos.MessageBus.Messages;

namespace InfoWoto.ServicoNotaAlunos.MessageBus.SQS.Clients
{
public class SqsClient<T> : IQueueClient<T>
{
    //quando eu coloco virtual eu dou a possibilidade de sobescrever o método
   public virtual Task DeleteMessageAsync(string messageHandle)
   {
     throw new NotImplementedException();
   }
  
   public virtual Task<QueueMessage<T>> GetMessageAsync()
   {
        throw new NotImplementedException();
   }

   public virtual Task<List<QueueMessage<T>>> GetMessageAsync(int count)
   {
        throw new NotImplementedException();
   }


   public virtual Task SendMessageAsync(T message)
   {
       throw new NotImplementedException();
   }

    public virtual Task SendMessageAsync(List<T> messageList)
   {
       throw new NotImplementedException();
   }
}
}


       

       

       

      

        