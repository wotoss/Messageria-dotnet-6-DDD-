namespace InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
    //como se fosse um repositorio base

    //tem o Idipososable, para obrigar cada classe de Repository a fazer o disposi.
    // where T : IRaizAgregacao vai implementar T Raiz de agregação.

    //Quem herdar no lugar  IRepository<T> passará a entidade
    public interface IRepository<T> : IDisposable where T : IRaizAgregacao
    {
        //esta passa a ser um propriedade somente de leitura.
         IUnitOfWork UnitOfWork { get; }
    }
