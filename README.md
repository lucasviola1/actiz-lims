# Tecnologias Utilizadas

.NET 8

Blazor (Front-end)

ASP.NET Core Web API (Back-end)

Entity Framework Core (ORM)

SQL Server (Banco de Dados)

JWT (Autenticação)

Swagger (Documentação da API)

# Requisitos

.NET SDK 8.0+

SQL Server

Visual Studio 2022 (ou superior) ou VS Code

# 1. Clone o repositório

git clone (https://github.com/lucasviola1/actiz-lims.git)
cd actiz-lims

# 2. Configure a ConnectionString

Abra o projeto com Visual Studio ou VS Code

Abra o arquivo appsettings.json actiz-lims>ActizLims.API>appsettings.json

Localize:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=LUCAS(servidor local);Database=ActizLimsDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}

Troque o nome de LUCAS para o nome do seu servidor local

Para achar o nome do seu servidor local:

Abra o SQL Server Management Studio.
Na janela de conexão, veja o campo Server name.
O valor que aparece nesse campo é o nome do seu servidor local.

Obs: certifique-se de que o SQL Server está rodando e você tem permissão para criar o banco.

# 3. Execute as migrations do Entity Framework Core

Abra o Console do Grenciador de Pacotes(Gerenciador de Pacotes do NuGet) e rode:

Update-Database;

Isso criará o banco de dados e aplicará as migrations.

# 4. Execute os projetos

Você pode rodar os dois projetos separadamente ou juntos pela solution no Visual Studio.

Opção 1 – Terminal

cd ActizLims.API
dotnet run

Em outro terminal (Blazor Front)
cd ../ActizLims.FrontBlazor
dotnet run

Opção 2 – Visual Studio

Defina os dois projetos para iniciarem juntos.

Clique em "Start" (F5).

# 5. Acessando a aplicação

Frontend Blazor: http://localhost:7017

API (Swagger): https://localhost:7228/swagger

# 6. Testes

Para rodar o teste basta entrar na pasta Actiz.Lims.Tests pelo terminal

Rodar o seguinte comando: 

dotnet test
