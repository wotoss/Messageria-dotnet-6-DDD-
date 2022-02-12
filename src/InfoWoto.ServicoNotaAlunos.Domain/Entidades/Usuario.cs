using System;
using InfoWoto.ServicoNotaAlunos.Domain.ValueObjects;

namespace InfoWoto.ServicoNotaAlunos.Domain.Entidades;
    //lembrando que ao herdar a (classe Entidade) estamos herdando o (Id)
    public class Usuario : Entidade
    {
        //(2º passo )
        //como colcamos as propriedades como privados, só podemos ter acesso através do construtor
        public Usuario(string nome, string documentoIdentificacao,  DateTime dataNascimento, bool ativo,
                       string email, Telefone telefoneContato, bool administrativo, DateTime dataCadastro )
        {
            Nome = nome;
            DocumentoIdentificacao = documentoIdentificacao;
            DataNascimento = dataNascimento;
            Ativo = ativo;
            Email = email;
            TelefoneContato = telefoneContato;
            Administrativo = administrativo;
            DataCadastro  =  dataCadastro;
        } 
        
        //(3º passo )
        //entity vai precisar de um (construtor vazio) para fazer a manipulação dos dados.
        protected Usuario(){ }
        
        //(1º passo)
        //vamos trabalhar com atributos privados para ajudar no encapsulamento
        //se eu quiser mudar o nome do usuario eu preciso ter um método que mude a propriedade.
        //Caso precise alterar usaremos (EdHook) métodos que alteram alguma propriedade.
        public string Nome { get; private set; }

        public string DocumentoIdentificacao { get; private set; }

        public DateTime DataNascimento { get; private set; }

        public bool Ativo { get; private set; }

        public string Email { get; private set; }

        //estamos usando nesta propriedade a estratégia ValueObject ou Objeto Valor
        //nesta abordagem eu crio uma classe, as propriedades, faço uma validação.
        //trago a refencia desta classe => using InfoWoto.ServicoNotaAlunos.Domain.ValueObjects;
        //por fim no lugar do tipo exemplo string eu passo a classe ValueObject. 
        //neste caso a classe => Telefone.
        public Telefone TelefoneContato { get; private set; }

        public bool Administrativo { get; private set; }

        public DateTime DataCadastro { get; private set; }

        //vamos dixar mapeado mas não tem chave estrangeira
        //relacionametno é opcional pois não guarda o ID
        public Aluno Aluno { get; private set; }

        public Professor Professor { get; private set; }
    }
