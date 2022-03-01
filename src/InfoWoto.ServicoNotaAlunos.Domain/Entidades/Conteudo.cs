

namespace InfoWoto.ServicoNotaAlunos.Domain.Entidades;
//lembrando que ao herdar a (classe Entidade) estamos herdando o (Id)
    public class Conteudo : Entidade
    {
    //(2º passo )
    //como colcamos as propriedades como privados, só podemos ter acesso através do construtor
    public Conteudo(string nome, string descricao, DateTime dataInicio,
                    DateTime dataTermino, DateTime dataCadastro)
    {
        Nome = nome;
        Descricao = descricao;
        DataInicio = dataInicio;
        DataTermino = dataTermino;
        DataCadastro = dataCadastro;
        Atividades = new List<Atividade>();
    }

   //(3º passo )
   //entity vai precisar de um (construtor vazio) para fazer a manipulação dos dados.
    protected Conteudo() { }

  
        //(1º passo)
        //vamos trabalhar com atributos privados para ajudar no encapsulamento
        //se eu quiser mudar o nome do usuario eu preciso ter um método que mude a propriedade.
        //Caso precise alterar usaremos (EdHook) métodos que alteram alguma propriedade.

        //Observação
        //Os get => são pubico você pode lêr 
        //Mas os Set => são privados
        //Só pode Atualizar os Set => Atraves dos Métodos ou contutores.
        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public DateTime DataInicio { get; private set; }

        public DateTime DataTermino { get; private set; }

        public DateTime DataCadastro { get; private set; }

        //relacionamento
        //um conteudo pertence a uma disciplina
        public Disciplina  Disciplina { get; private set; }


        //um conteudo tem muitas atividades
        public ICollection<Atividade> Atividades { get; private set; }

        //para não alterar o encapsulamento da classe Atividade

        public void CadastrarAtividade(Atividade atividade) =>
             Atividades.Add(atividade);
    }
  
