using InfoWoto.ServicoNotaAlunos.Data.Context;
using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
using InfoWoto.ServicoNotaAlunos.Domain.Entidades;
using InfoWoto.ServicoNotaAlunos.Domain.Interfaces.Repositories;

namespace InfoWoto.ServicoNotaAlunos.Data.Repositories;

public class DisciplinaRepository : IDisciplinaRepository
    {
    private readonly FakeDbContexto _contexto;

    public DisciplinaRepository(FakeDbContexto contexto)
    {
        _contexto = contexto;
    }
    public IUnitOfWork UnitOfWork => _contexto;

    public async Task<Disciplina> BuscarDisciplinaPorAtividadeId(int atividadeId) =>
       await Task.FromResult(_contexto.Disciplinas.FirstOrDefault(x => x.Conteudos.SelectMany(y => y.Atividades)
       .Any(y => y.Id == atividadeId)));

    public void Dispose()
    {
    //interrogação significa se ele existir (?)
    //este dispose esta implementado => FakeDbContexto.Dispose()
       _contexto?.Dispose();
    }
    
}
