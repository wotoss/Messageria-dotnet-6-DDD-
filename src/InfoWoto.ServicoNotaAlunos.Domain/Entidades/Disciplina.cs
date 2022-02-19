
using InfoWoto.ServicoNotaAlunos.Domain.Enums;
using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;

namespace InfoWoto.ServicoNotaAlunos.Domain.Entidades;


public class Disciplina : Entidade, IRaizAgregacao
{
    public Disciplina (string nome, string descricao, DateTime dataInicio, DateTime dataFim,
                       TipoDisciplina tipoDisciplina, DateTime dataCadastro, int professorId)
    {
        Nome = nome;
        Descricao = descricao;
        DataInicio = dataInicio;
        DataFim = dataFim;
        TipoDisciplina =  tipoDisciplina;
        DataCadastro = dataCadastro;
        ProfessorId = professorId;
        Conteudos = new List<Conteudo>();
    }

    protected Disciplina ( ){ }

    public string Nome { get; private set; }

    public string Descricao { get; private set; }

    public DateTime DataInicio { get; private set; }

    public DateTime DataFim { get; private set; }

    public TipoDisciplina TipoDisciplina { get; private set; }

    public DateTime DataCadastro { get; private set; }
    
    //este é o relacionamento disciplina tem professor.
    public int ProfessorId { get; private set; }
    

    //relacionado
    //uma disciplina pertence a um professor.
    public Professor Professor { get; private set; }
    
    //uma disciplina tem varios conteudos.
    public ICollection<Conteudo> Conteudos { get; private set; }
}