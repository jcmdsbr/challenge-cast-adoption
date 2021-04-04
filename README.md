# Desafio Cast :sunglasses:

- Aplicação voltada para controle de adoções de animais utilizando  ASP.NET Core 2.1 com DDD e CQRS.

## Estrelinha! :star:

Se esse projeto te ajudou em alguma coisa, taquele pau na estrelinha \o/

## Para rodar esse projeto, você vai precisar das seguintes ferramentas :exclamation:

- Visual Studio 2019, Visual Studio Code or Rider
- .Net Core 5.X +

## Tecnologias Implementadas 🚧

- ASP.NET Core 2.1 (with .NET Core)
- ASP.NET MVC Core
- Entity Framework Core 2.1
- .NET Core Native DI
- FluentValidator
- Dapper

## Arquitetura 🏗️

- Domain Driven Design (Layers and Domain Model Pattern)
- CQRS (Imediate Consistency)
- Unit of Work
- Repository Pattern


## Primeiros Passos ✔️

-  1º Configurar a string de conexão ao banco de dados no arquivo appsettings.json do projeto Código Fonte/SGA/SGA.UI.Site
-  2º Executar os seguites commandos no Package Manager Console:

```bash
--> "Update-Database -Context SgaIdentityDbContext" no projeto Código Fonte/SGA/SGA.Infra.CrossCutting.Identity/
--> "Update-Database -Context SGAContext" no projeto Código Fonte/SGA/SGA.Infra.Data/
```

- 3º Rodar scripts de alimentação que estão na pasta "DesafioCast/Banco de Dados/":

```bash
--> "SCRIPT_GENERATE_TYPE_PETS.sql"  
--> "SCRIPT_GENERATE_USER.sql" contidos na pasta 
```

- 4º Rodar as procedures que estão na pasta "DesafioCast/Banco de Dados/Procedures"
 
## Login de Acesso ❗

- Usuario : admin
- Senha: admin123

## Próximos passos 📖

- Criar fluxos alternativos para deletar e detalhar os Responsáveis (documentação e código fonte).
- Criar fluxos alternativos para deletar e detalhar os Animais  (documentação e código fonte).
- Implementar Log de rastreabilidade das ações efetuadas.
- Melhorar usabilidade da aplicação.

