Tecnologias Utilizadas

.NET 8

Blazor (Front-end)

ASP.NET Core Web API (Back-end)

Entity Framework Core (ORM)

SQL Server (Banco de Dados)

JWT (Autenticação)

Swagger (Documentação da API)

Requisitos

.NET SDK 8.0+

SQL Server

Visual Studio 2022 (ou superior) ou VS Code

1. Clone o repositório

git clone https://github.com/seu-usuario/ActizLims.git
cd ActizLims

2. Configure a ConnectionString

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ActizLimsDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}

Obs: certifique-se de que o SQL Server está rodando e você tem permissão para criar o banco.

3. Execute as migrations do Entity Framework Core

Abra o terminal na pasta ActizLims.API e rode:

dotnet ef database update

ou

Abra o Console do Grenciador de Pacotes(Package Manager) e rode:

Add-Migration v1(nome da sua escolha);

Update-Database;

Isso criará o banco de dados e aplicará as migrations.

4. Execute os projetos

Você pode rodar os dois projetos separadamente ou juntos pela solution no Visual Studio.

Opção 1 – Terminal

cd ActizLims.API
dotnet run

# Em outro terminal (Blazor Front)
cd ../ActizLims.FrontBlazor
dotnet run

Opção 2 – Visual Studio

Defina os dois projetos para iniciarem juntos.

Clique em "Start" (F5).

5. Acessando a aplicação

Frontend Blazor: http://localhost:5002 (ou porta configurada)

API (Swagger): https://localhost:7228/swagger

