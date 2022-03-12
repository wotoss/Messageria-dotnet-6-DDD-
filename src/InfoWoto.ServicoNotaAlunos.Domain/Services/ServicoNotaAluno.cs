
using InfoWoto.ServicoNotaAlunos.Domain.Messages;
using InfoWoto.ServicoNotaAlunos.Domain.Interfaces.Services;
using InfoWoto.ServicoNotaAlunos.Domain.Notification;
using InfoWoto.ServicoNotaAlunos.Domain.Interfaces.Repositories;
using InfoWoto.ServicoNotaAlunos.Domain.Excecoes;
using  InfoWoto.ServicoNotaAlunos.Domain.Utils;
using InfoWoto.ServicoNotaAlunos.Domain.Entidades;
using InfoWoto.ServicoNotaAlunos.Domain.DomainObjects;
using InfoWoto.ServicoNotaAlunos.Domain.Validations.Handlers;

namespace InfoWoto.ServicoNotaAlunos.Domain.Services;
    //esta classe implementa o contrato do IServicoNotaAluno
    public class ServicoNotaAluno : IServicoNotaAluno
    {
        
        private readonly ContextoNotificacao _contextoNotificacao;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;

        private readonly IServicoValidacaoNotaAluno _servicoValidacaoNotaAluno;
    
     public ServicoNotaAluno(ContextoNotificacao contextoNotificacao,
                           IUsuarioRepository usuarioRepository, 
                           IDisciplinaRepository disciplinaRepository,
                           IServicoValidacaoNotaAluno servicoValidacaoNotaAluno)
    
    {
        _contextoNotificacao = contextoNotificacao;
        _usuarioRepository = usuarioRepository;
        _disciplinaRepository = disciplinaRepository;
        _servicoValidacaoNotaAluno = servicoValidacaoNotaAluno;
    }
    /*
    * Diminuios a ida ao banco (Input output IO) que seria um processo custoso
    * A execessão tambem é um processo custoso porque eu tenho que trata-la na camada.
    * 
    */

            public async Task LancarNota(RegistrarNotaAluno registrarNotaAluno)
            {
            Console.WriteLine("Processando lógica de negocios....");

            if (!registrarNotaAluno.MensagemEstaValida())
            {
                //chamando o método que adiciona as mensagens de erro
                AdicionarMensagemErroNoContexto(registrarNotaAluno);
                //caso tenha erro eu Adiciono no contexto (AddRange) e retorno. 
                return;
             }
          
             //var (aluno, professor, disciplina) = await BuscarAlunoProfessorDisciplina2(registrarNotaAluno);

             var request = await ConstruirRequest(registrarNotaAluno);

             if(_contextoNotificacao.TemNotificacoes)
             return;

             //_servicoValidacaoNotaAluno.ValidarLancamento(aluno, professor, disciplina);

              _servicoValidacaoNotaAluno.ValidarLancamento(request);

             if(_contextoNotificacao.TemNotificacoes)
             return;
               
           }

           private async Task<ServicoNotaValidacaoRequest> ConstruirRequest(RegistrarNotaAluno registrarNotaAluno)
            {
                var request = new ServicoNotaValidacaoRequest();
                request.AlunoId = registrarNotaAluno.AlunoId;
                request.ProfessorId = registrarNotaAluno.ProfessorId;
                request.AtividadeId = registrarNotaAluno.AtividadeId;

                var initialHandler = new AlunoRequestBuildHandler(_contextoNotificacao,
                                                           _usuarioRepository);
                initialHandler.SetNext(new ProfessorRequestBuildHandler(_contextoNotificacao,
                                                           _usuarioRepository))
                              .SetNext(new DisciplinaRequestBuildHandler(_contextoNotificacao, 
                                                           _disciplinaRepository));   
                await initialHandler.Handle(request);
                //preencho o meu request no await e retorno ele no retorn
                return request;                                                                   
            }

      
            //estamos montando e pensando em precessamentos de acordo com posição dos métodos
            //exemplo não sentido em continuar caso o aluno não exista. nem vou para o professor e disciplina.
            //isto economiza processamento.
            private void CodigosExemplo()
            {
            //var aluno = await _usuarioRepository.BuscarAluno(registrarNotaAluno.AlunoId);
            //var professor = await _usuarioRepository.BuscarProfessor(registrarNotaAluno.ProfessorId);
            //var disciplina = await _disciplinaRepository.BuscarDisciplinaPorAtividade(registrarNotaAluno.AtividadeId);
            
            //esta WhenAll => pode receber uma lista de tarefas.

            //await Task.WhenAll(new List<Task> {aluno, professor, disciplina});
           
           //neste caso ele já cria uma =>varivael = aluno, variavel = professor, variavel disciplina.
           //var (aluno, professor, disciplina) = await BuscarAlunoProfessorDisciplina(registrarNotaAluno);
             }


        //TENTANDO DIMINUIR O PROCESSAMENTO
           private async Task<(Aluno aluno, Professor professor, Disciplina disciplina)> BuscarAlunoProfessorDisciplina2(RegistrarNotaAluno registrarNotaAluno)

             {
              //estamos montando e pensando em precessamentos de acordo com posição dos métodos
            //exemplo não sentido em continuar caso o aluno não exista. nem vou para o professor e disciplina.
            //isto economiza processamento.
            
            //então vamos lá com as excessões se o aluno vinher nullo => ?? throw new Exception(""); eu não deixo prosseguir
            var aluno = await _usuarioRepository.BuscarAluno(registrarNotaAluno.AlunoId);

            //evitou mandar uma excessão
            if(aluno is null)
            {
               _contextoNotificacao.Add(Constantes.MensagensExcecao.ALUNO_INEXISTENTE);
               return (null, null, null);
            }

            //se ele chegou até aqui o aluno existe. então vou devolver o aluno no return
            var professor = await _usuarioRepository.BuscarProfessor(registrarNotaAluno.ProfessorId);
            if(professor is null)
            {
               _contextoNotificacao.Add(Constantes.MensagensExcecao.PROFESSOR_INEXISTENTE);
               return(aluno, null, null);
            }
                       

            var disciplina = await _disciplinaRepository.BuscarDisciplinaPorAtividadeId(registrarNotaAluno.AtividadeId);
            if (disciplina is null)
            {
                _contextoNotificacao.Add(Constantes.MensagensExcecao.DISCIPLINA_INEXISTENTE);
                return(aluno, professor, null);
            }         
            
            //estou montando uma tupla é uma forma de retornar varios valores sem criar um  modelagem de um objeto.
            return (aluno, professor, disciplina);
        }

        private async Task<(Aluno aluno, Professor professor, Disciplina disciplina)> BuscarAlunoProfessorDisciplina(RegistrarNotaAluno registrarNotaAluno)

        {
              //estamos montando e pensando em precessamentos de acordo com posição dos métodos
            //exemplo não sentido em continuar caso o aluno não exista. nem vou para o professor e disciplina.
            //isto economiza processamento.
            
            //então vamos lá com as excessões se o aluno vinher nullo => ?? throw new Exception(""); eu não deixo prosseguir
            var aluno = await _usuarioRepository.BuscarAluno(registrarNotaAluno.AlunoId)
                        ?? throw new DomainException(Constantes.MensagensExcecao.ALUNO_INEXISTENTE);

            var professor = await _usuarioRepository.BuscarProfessor(registrarNotaAluno.ProfessorId) 
                        ?? throw new DomainException(Constantes.MensagensExcecao.PROFESSOR_INEXISTENTE);

            var disciplina = await _disciplinaRepository.BuscarDisciplinaPorAtividadeId(registrarNotaAluno.AtividadeId) 
                        ?? throw new DomainException(Constantes.MensagensExcecao.DISCIPLINA_INEXISTENTE);
            
            //estou montando uma tupla é uma forma de retornar varios valores sem criar um  modelagem de um objeto.
            return (aluno, professor, disciplina);
        }

        //trabalhando com os nulos
      
        //este 
        private void AdicionarMensagemErroNoContexto(RegistrarNotaAluno registrarNotaAluno)
        {
             //este é o caminho onde estará nossas mensagens de erro...
             //ele adiciona estas mensagens de erro no _contextoNotificacao
             _contextoNotificacao.AddRange(registrarNotaAluno.Validacoes.Errors.Select(x => x.ErrorMessage));
        }
    }

