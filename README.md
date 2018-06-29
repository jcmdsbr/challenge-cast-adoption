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
- CQRS (Imediate Consistency)
- Unit of Work
- Repository Pattern

# Pré Requisitos:
- Ter instalado a sdk do asp.net core 2.1 rlc. 
- Link para donwload: https://github.com/dotnet/versions/tree/7a833dddfddc27f2074b755b94234a25b9757637/build-info/dotnet/product/cli/release/2.1
- Ter vscode ou visual studio 2017 para rodar o projeto. 
-  Link para donwload: https://visualstudio.microsoft.com/

# Primeiros Passos:
-  1º Configurar a string de conexão ao banco de dados no arquivo appsettings.json do projeto Código Fonte/SGA/SGA.UI.Site
-  2º Executar os seguites commandos no Package Manager Console:

"Update-Database -Context SgaIdentityDbContext" no projeto Código Fonte/SGA/SGA.Infra.CrossCutting.Identity/

"Update-Database -Context SGAContext" no projeto Código Fonte/SGA/SGA.Infra.Data/

- 3º Rodar scripts de alimentação "SCRIPT_GENERATE_TYPE_PETS.sql" e "SCRIPT_GENERATE_USER.sql" contidos na pasta 
"DesafioCast/Banco de Dados/"
 
# Login de Acesso:
- Usuario : admin
- Senha: admin123

# TODO:
- Criar fluxos alternativos para deletar e detalhar os Responsáveis (documentação e código fonte).
- Criar fluxos alternativos para deletar e detalhar os Animais  (documentação e código fonte).
- Implementar Log de rastreabilidade das ações efetuadas.
- Melhorar usabilidade da aplicação.

## Scan Sonar: https://sonarcloud.io/dashboard?id=sga.visualstudio.com
## Template CSS Utilizado : https://startbootstrap.com/template-overviews/freelancer/ 
