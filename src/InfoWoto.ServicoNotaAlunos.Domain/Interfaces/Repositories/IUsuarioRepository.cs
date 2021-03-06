using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
using InfoWoto.ServicoNotaAlunos.Domain.Entidades;

namespace InfoWoto.ServicoNotaAlunos.Domain.Interfaces.Repositories;
public interface IUsuarioRepository : IRepository<Usuario>
{
    //isto é um task que vai ter como retorno um <Aluno>
    Task<Aluno> BuscarAluno(int alunoId);

    //isto é um task que vai ter como retorno um <Professor>
    Task<Professor> BuscarProfessor(int professorId);
}
