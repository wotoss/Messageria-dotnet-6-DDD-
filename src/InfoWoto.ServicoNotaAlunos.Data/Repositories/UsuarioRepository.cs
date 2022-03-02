using InfoWoto.ServicoNotaAlunos.Data.Context;
using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
using InfoWoto.ServicoNotaAlunos.Domain.Entidades;
using InfoWoto.ServicoNotaAlunos.Domain.Interfaces.Repositories;

 namespace InfoWoto.ServicoNotaAlunos.Data.Repositories;
public class UsuarioRepository : IUsuarioRepository
{
    private readonly FakeDbContexto _contexto;

    public UsuarioRepository(FakeDbContexto contexto)
    {
        _contexto = contexto;
    }
    public IUnitOfWork UnitOfWork => _contexto;

    public async Task<Aluno> BuscarAluno(int alunoId) =>
    //estamos fazendo a busca do nosso primeiro aluno com FirstOrDefault
    await Task.FromResult(_contexto.Alunos.FirstOrDefault(x => x.Id == alunoId));
   

    public async Task<Professor> BuscarProfessor(int professorId) =>
    //estamos fazendo a busca do nosso primeiro aluno com FirstOrDefault
    await Task.FromResult(_contexto.Professores.FirstOrDefault(x => x.Id == professorId));
    

    public void Dispose()
    {
        //interrogação significa se ele existir (?)
        //este dispose esta implementado => FakeDbContexto.Dispose()
        _contexto?.Dispose();
    }
}
