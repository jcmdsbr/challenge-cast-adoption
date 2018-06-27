# DesafioCast
- Aplicação voltada para controle de adoções de animais utilizando  ASP.NET Core 2.1 com DDD e CQRS.

## Tecnologias Implementadas
- ASP.NET Core 2.1 (with .NET Core)
- ASP.NET MVC Core
- Entity Framework Core 2.1
- .NET Core Native DI
- FluentValidator

# Arquitetura:
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Notification
- CQRS (Imediate Consistency)
- Unit of Work
- Repository Pattern

# Primeiros Passos:
-  1º Configurar a string de conexão ao banco de dados no arquivo appsettings.json do projeto Código Fonte/SGA/SGA.UI.Site
-  2º Executar os seguites commandos no Package Manager Console:
-  Update-Database -Context SgaIdentityDbContext no projeto Código Fonte/SGA/SGA.Infra.CrossCutting.Identity/
-  Update-Database -Context SGAContext no projeto Código Fonte/SGA/SGA.Infra.Data/

# Login de Acesso:
- Usuario : admin
- Senha: admin123

# TODO
- Criar fluxos alternativos para deletar e detalhar os Responsáveis (documentação e código fonte).
- Criar fluxos alternativos para deletar e detalhar os Animais  (documentação e código fonte).
- Implementar Log de rastreabilidade das ações efetuadas.
- Melhorar usabilidade da aplicação.

## Template Utilizado : https://startbootstrap.com/template-overviews/freelancer/ 
