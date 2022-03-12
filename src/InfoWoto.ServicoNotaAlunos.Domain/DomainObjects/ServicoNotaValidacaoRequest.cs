
using InfoWoto.ServicoNotaAlunos.Domain.Entidades;

namespace InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;


//não uma entidade => é praticamente um DTO => seria um transporte de dados.
public class ServicoNotaValidacaoRequest
{
    
    public static ServicoNotaValidacaoRequest Instance => new ServicoNotaValidacaoRequest();
    public int AlunoId { get; set; }
    public Aluno Aluno { get; set; }
    public int ProfessorId { get; set; }
    public Professor Professor { get; set; }
    public int AtividadeId { get; set; }
    public Disciplina Disciplina { get; set; }
}