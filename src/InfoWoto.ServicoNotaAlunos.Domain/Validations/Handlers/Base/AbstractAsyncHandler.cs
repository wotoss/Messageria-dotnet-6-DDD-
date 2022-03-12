
using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
using InfoWoto.ServicoNotaAlunos.Domain.Validations.Handlers.Interface;
namespace InfoWoto.ServicoNotaAlunos.Domain.Validations.Handlers.Base;


//Com o where T estou dizendo que o nosso T generico terá um filtro e so aceita esta classe ServicoNotaValidacaoRequest
public class AbstractAsyncHandler<T> : IAsyncHandler<T> where T : ServicoNotaValidacaoRequest
{
    private IAsyncHandler<T> _nextHandler;
    public virtual async Task Handle(T request)
    {
        if (this._nextHandler != null)
        {
            await this._nextHandler.Handle(request);
        }
    }

    public IAsyncHandler<T> SetNext(IAsyncHandler<T> handler)
    {
       _nextHandler = handler;
       return handler;
    }
}