using System;
using System.Collections.Generic;

namespace InfoWoto.ServicoNotaAlunos.Domain.Entidades;

public class Aluno : Entidade
{
   //(2º passo )
    //como colocamos as propriedades como privados, só podemos ter acesso através do construtor
    public Aluno(int AlunoId, string nomeAbreviado, string emailInterno, int usuarioId,  DateTime dataCadastro)
    {
       Id = AlunoId;
       NomeAbreviado =  nomeAbreviado;
       EmailInterno = emailInterno;
       UsuarioId = usuarioId;
       DataCadastro =  dataCadastro;
       Notas = new List<Nota>();
       AlunosTurmas = new List<AlunosTurmas>();
    }
     //(3º passo )
     //entity (ORM) vai precisar de um (construtor vazio) para fazer a manipulação dos dados.
     protected Aluno() { }

    //lembrando que ao herdar a (classe Entidade) estamos herdando o (Id)
    //(1º passo)
    //vamos trabalhar com atributos privados para ajudar no encapsulamento
    //se eu quiser mudar o nome do usuario eu preciso ter um método que mude a propriedade.
    //Caso precise alterar usaremos (EdHook) métodos que alteram alguma propriedade.
    
        public string NomeAbreviado { get; private set; }

        public string EmailInterno { get; private set; }
        
    //este irar ser o relacionamento de usuário para aluno foreing key
        public int UsuarioId { get; private set; }

        public DateTime DataCadastro  { get; private set; }

        //relacionamento de Aluno
        public Usuario Usuario { get; private set; }

        //relacionameto, uma coleção de notas
        public ICollection<Nota> Notas { get; private set; }
        
        //relacionamento, uma coleção de turmas.
        public ICollection<AlunosTurmas> AlunosTurmas { get; private set; }

        //vou criar um método adicionar notas
        public void AdicionarNota(Nota nota)
        {
            //validar nota
            Notas.Add(nota);
        }

}