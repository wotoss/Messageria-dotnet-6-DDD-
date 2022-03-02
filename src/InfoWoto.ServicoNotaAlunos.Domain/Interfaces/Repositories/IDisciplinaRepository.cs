
using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
using InfoWoto.ServicoNotaAlunos.Domain.Entidades;

namespace InfoWoto.ServicoNotaAlunos.Domain.Interfaces.Repositories;


public interface IDisciplinaRepository : IRepository<Disciplina>
{
    //teremos os métodos dos contratos...
    //esta task me trará o retorno de uma Disciplina
    Task<Disciplina> BuscarDisciplinaPorAtividade(int atividadeId);
}