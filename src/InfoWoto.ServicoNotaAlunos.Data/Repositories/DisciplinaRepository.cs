using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
using InfoWoto.ServicoNotaAlunos.Domain.Interfaces.Repositories;

namespace InfoWoto.ServicoNotaAlunos.Data.Repositories;

public class DisciplinaRepository : IDisciplinaRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public void Dispose()
        {

        }
    
    }
