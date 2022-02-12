using System;
using System.Collections.Generic;
using InfoWoto.ServicoNotaAlunos.Domain.Enums;

namespace InfoWoto.ServicoNotaAlunos.Domain.Entidades;

    public class Atividade : Entidade
    {
       public Atividade(string descricao, TipoAtividade tipoAtividade, DateTime dataAtividade,
                        DateTime dataCadastro,  bool possuiRetentativa)
       {
           Descricao = descricao;
           TipoAtividade = tipoAtividade;
           DataAtividade = dataAtividade;
           DataCadastro =  dataCadastro;
           PossuiRetentativa = possuiRetentativa;
           Notas = new List<Nota>();
       }

        protected Atividade() { }

        public string Descricao { get; private set; }
        
        //estamos usando nesta propriedade a estratégia Enum 
        //nesta abordagem eu crio uma classe Enum, nesta classe passo as opções correspondente
        //trago a refencia desta classe => using InfoWoto.ServicoNotaAlunos.Domain.Enums;
        //por fim no lugar do tipo (exemplo string) eu passo a classe Enum. 
        //neste caso a classe => TipoAtividade.
        public TipoAtividade TipoAtividade { get; private set; }

        public DateTime DataAtividade { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public bool PossuiRetentativa { get; private set; } 

        //relacionamento
        //uma atividade pertence a um conteudo 
        public Conteudo Conteudo { get; private set; }
        
        //uma atividade tem uma ou mais notas.
        public ICollection<Nota> Notas { get; private set; }
    }
