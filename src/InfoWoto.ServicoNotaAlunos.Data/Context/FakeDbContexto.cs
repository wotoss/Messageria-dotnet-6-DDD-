using InfoWoto.ServicoNotaAlunos.Domain.Entidades;
using InfoWoto.ServicoNotaAlunos.Domain.Enums;
using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;

namespace InfoWoto.ServicoNotaAlunos.Data.Context;

    public class FakeDbContexto : IDisposable, IUnitOfWork
    {
        public FakeDbContexto()
        {
            Alunos = AlunoFake();
            Professores = ProfessoresFake();
            Disciplinas = DisciplinasFake();
        }

        public ICollection<Aluno> Alunos { get; set; }

        public ICollection<Professor> Professores { get; set; }

        public ICollection<Disciplina> Disciplinas { get; set; }
        
        //existe uma biblioteca chama(bogus) para gerar dados falsos é uma oportunidade.
        private ICollection<Aluno> AlunoFake()
        {
            var alunos = new List<Aluno>();

            Aluno aluno = new(1234, "Raphael", "raphael.s@email.com", 1212, DateTime.Now);
            /*
            aluno.AlunosTurmas = new List<AlunosTurmas>() 
            { 
            new(1234,10019,DateTime.Now) 
            {
                Turma =
                    new("Grupo Matemática I", Periodo.Noturno, new DateTime(2021,06,01),
                    new DateTime(2021,12,01), DateTime.Now, 1341567)
            } 
           };*/
            
            alunos.Add(aluno);

            return alunos;
        }

        private ICollection<Professor> ProfessoresFake()
        {
            var professores = new List<Professor>();

            Professor professor = new(1282727, "Danilo", "danilo.s@email.com", true, false, 1212, DateTime.Now,  1341567);
            
            professores.Add(professor);

            return professores;
        }

        private ICollection<Disciplina> DisciplinasFake()
        {
            var disciplinas = new List<Disciplina>();

            var disciplina = new Disciplina("Matemática", "Matemática base ensino médio"
            , new DateTime(2021,10,12), new DateTime(2021,02,12), TipoDisciplina.Teorica,
            new DateTime(2021, 09, 12), 1282727);

            var conteudo = new Conteudo("Equação segundo grau", "Aprendizado de equações de segundo grau",
            new DateTime(2021,10,18), new DateTime(2021,11,18), new DateTime(2021,10,15));

            var atividade = new Atividade(34545, "Atividade avaliativa equações", TipoAtividade.Avaliativa,
            new DateTime(2021,11,10), new DateTime(2021, 11, 01), false);

            conteudo.CadastrarAtividade(atividade);

            disciplina.AdicionarConteudo(conteudo);

            disciplinas.Add(disciplina);

            return disciplinas;
        }

         public async Task<bool> Commit()
            //este commit vai retornar
            => await Task.FromResult(true);
         

         public void Dispose()
         {
             //Console nos vamos ver em que momento ele vai fazer o dispose desta classe.
             //Ou a limpeza dela.
            Console.WriteLine("Fazendo liberação de recursos...");
         }
    }
