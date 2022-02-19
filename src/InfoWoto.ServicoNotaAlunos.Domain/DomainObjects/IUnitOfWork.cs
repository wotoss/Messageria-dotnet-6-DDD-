namespace InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
    public interface IUnitOfWork
    { 
       //ele obriga a quem herdar desta interface a implementar o Commit
       //quando eu der um commit no contexto, eu estarei aceitando o contexto geral
       //ou seja quando eu der commit estarei aceitando a todas as mudanças que terei em memoria.
       //O contexto que eu digo são todas as minhas entidades.

       //assim que funciona o transacional do commit
       Task<bool> Commit();
    }
