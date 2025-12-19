# Desafio Técnico - MAXIPROD

Este repositório consiste na implementação do desafio técnico da empresa Maxiprod.

## Objetivo
Implementar um sistema de controle de gastos.

## Organização

```
controle-gastos/
├── backend/
│   ├── ControleGastos.Api/
│   └── ControleGastos.sln
├── frontend/
└── README.md

```

### Back-End
* C#
* .NET 8.0
* SQLite
* API com Controllers
* Swagger para documentação

#### Rodando o back-end
Realize as _migrations_ 
>dotnet ef database update

Rodar o projeto
>cd backend/ControleGastos.Api
>dotnet run 

Veja a documentação do swagger em: ```http://localhost:5183/swagger```

### Front-End
* React
* TypeScript
* Vite
* Axios

#### Rodando o front-end
>cd frontend
> 
>npm install
> 
>npm run dev

## Referências
- https://www.youtube.com/watch?v=dQJTONwxi3Q
- https://stackoverflow.com/questions/77627624/sqlite-cannot-apply-aggregate-operator-sum-on-expressions-of-type-decimal-u
- https://www.youtube.com/watch?v=g3is3wQK70Q
- https://medium.com/@codezone/understanding-the-performance-difference-between-firstordefault-and-find-in-c-53c169fd9a2a
- https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/cs1591