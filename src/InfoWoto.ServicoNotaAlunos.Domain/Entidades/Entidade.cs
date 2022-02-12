
namespace InfoWoto.ServicoNotaAlunos.Domain.Entidades;


    //esta classe Entidade é uma (classe abstrata) isto significa que  ela só pode ser herdada
    //pelas outras classes dentro da (camada domain de dominio).
    //neste contexto => toda classe que herdar desta classe terá (herdará um Id).
    public abstract class Entidade
    {
        public int Id { get; private set; }
    }
