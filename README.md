# Comando para listar os projetos


# Comando para adicionar projetos a solução vazia
```bash
A partir de uma solução criada digitamos o comando para adicionar a referencia ao csproj dos projetos.
   dotnet sln add src\InfoWoto.ServicoNotaAlunos.Worker\InfoWoto.ServicoNotaAlunos.Worker.csproj
   dotnet sln remove src\InfoWoto.ServicoNotaAlunos.Worker\InfoWoto.ServicoNotAlunos.Worker.csproj

   biblioteca de classe criada, camada aplicação => dotnet new classlib --name InfoWoto.ServicoNotaAlunos.Application

   biblioteca de classe criada, camada acesso a Dados => dotnet new classlib --name InfoWoto.ServicoNotaAlunos.Data

   biblioteca de classe criada, camada de comunicação com todas as outras camadas e tambem de injeção de dependencia vai tudo nesta camada para compartilhar com as outras camadas => dotnet new classlib --name InfoWoto.ServicoNotaAlunos.IOC

    biblioteca de classe criada, camada das entidades => dotnet new classlib --name InfoWoto.ServicoNotaAlunos.Domain

    Resumo => Camadas 
        => IOC: Concentra toda a injeçao de dependencia e todo comunicação passar por ela.
        => Domain: Nossas regras de negocios, onde teremos nossas entidades, conversa entre as entidades.
        => Application: Esta camada determina o fluxo da aplicação. Vai orquestrar as tarefas. Neste nosso com texto a (fila ou mensageria) o momento que vai chamar um serviço de dominio para execultar uma ação.
```