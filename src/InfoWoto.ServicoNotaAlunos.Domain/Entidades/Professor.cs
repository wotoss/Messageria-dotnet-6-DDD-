

namespace InfoWoto.ServicoNotaAlunos.Domain.Entidades;

    public class Professor : Entidade
    {
    //(2º passo )
    //como colcamos as propriedades como privados, só podemos ter acesso através do construtor
    
    public Professor(int professorId, string nomeAbreviado, string emailInterno,  bool professorTitular, bool professorSuplente,
           int usuarioId,  DateTime dataCadastro)
     //somente o (construtor ou algum método) consegue alterar a classe, pois as minha propriedade get e set são privadas      
    {
       Id = professorId;
       NomeAbreviado = nomeAbreviado;
       EmailInterno = emailInterno;
       ProfessorTitular = professorTitular;
       ProfessorSuplente = professorSuplente;
       UsuarioId = usuarioId;
       DataCadastro =  dataCadastro;
    }

    //(3º passo )
    //entity vai precisar de um (construtor vazio) para fazer a manipulação dos dados.
    protected Professor() { }
    
    //(1º passo)
    //vamos trabalhar com atributos privados para ajudar no encapsulamento
    //se eu quiser mudar o nome do usuario eu preciso ter um método que mude a propriedade.
    //Caso precise alterar usaremos (EdHook) métodos que alteram alguma propriedade.
    
        public string NomeAbreviado { get; private set; }

        public string EmailInterno { get; private set; }

        public bool ProfessorTitular { get; private set; }

        public bool ProfessorSuplente { get; private set; }

        public int UsuarioId { get; private set; }

        public DateTime DataCadastro { get; private set; }

        //relacionamento
        public Usuario Usuario { get; private set; }

        public Disciplina Disciplina { get; private set; }
    }

