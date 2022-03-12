using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
using InfoWoto.ServicoNotaAlunos.Domain.Validations.Handlers.Interface;

namespace InfoWoto.ServicoNotaAlunos.Domain.Validations.Handlers.Base;

//Com o where T estou dizendo que o nosso T generico terá um filtro e so aceita esta classe ServicoNotaValidacaoRequest
public abstract class AbstractHandler<T> : IHandler<T> where T : ServicoNotaValidacaoRequest
{
    private IHandler<T> _nextHandler;

    //coloquei o virtual para poder sobescrever este método em override.
    public virtual void Handle(T request)
    {
       if (this._nextHandler != null)
          {
              this._nextHandler.Handle(request);
          }
    }

    public IHandler<T> SetNext(IHandler<T> handler)
    {
       _nextHandler = handler;           
       return handler;
    }
}
