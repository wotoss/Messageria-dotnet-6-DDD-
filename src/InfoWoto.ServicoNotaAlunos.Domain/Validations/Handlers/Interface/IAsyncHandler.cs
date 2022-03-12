
namespace InfoWoto.ServicoNotaAlunos.Domain.Validations.Handlers.Interface;


public interface IAsyncHandler<T>
{
   IAsyncHandler<T> SetNext(IAsyncHandler<T> handler);      
   Task Handle(T request);

}