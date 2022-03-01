
namespace InfoWoto.ServicoNotaAlunos.Domain.Entidades;


    //esta classe Entidade é uma (classe abstrata) isto significa que  ela só pode ser herdada
    //pelas outras classes dentro da (camada domain de dominio).
    //neste contexto => toda classe que herdar desta classe terá (herdará um Id).
    public abstract class Entidade
    {
        //Quando eu desço um nivel e coloco a propriedade como protected => Eu permito que quem
        //herdar de entiti possa (setar um valor).
        //Se eu deixar como (privado) seria uma proteção de alto nivel para quem herdar de entity (não possa setar o valor)
        public int Id { get; protected set; }
    }
