namespace InfoWoto.ServicoNotaAlunos.Domain.Validations.Handlers.Interface;


    // Li a documentação e mudei algumas parametro ou inves de esperar object eu passei <T> generico
    //agora eu passo dizer que o meu handler é manipulador de um tipo de request.
    public interface IHandler<T>
    {
        IHandler<T> SetNext(IHandler<T> handler);
        
        void Handle(T request);
    }
