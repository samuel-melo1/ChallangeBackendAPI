# Challenge Backend API

Esse é um projeto construído com  **C#, ASP.NET, Entity Framework, PostgreSQL como banco de dados e SWAGGER para documentação e teste de rotas. .** 


A API foi desenvolvida com base em um desafio de backend utilizando C#. Em resumo, o projeto consiste em uma api que é possível realizar um cadastro de cliente. Esse cadastro de cliente contém validações como, por exemplo, não deixar que seja salvo dois clientes com o mesmo CNPJ. E por fim,  possui operações para Excluir, Listar, Editar um cliente que foi salvo.


## Indice

- [Instalaçao](#instalação)
- [Usabilidade](#usabilidade)
- [API Endpoints](#api-endpoints)
- [Banco de Dados](#banco-de-dados)
- [Contribuição](#contribuição)

## Instalação

1. Clone o repositório:

```bash
git clone https://github.com/samuel-melo1/ChallangeBackendAPI.git
```

2. Instale as dependências utilizando o próprio visual studio: 
    - Entity Framework 5.0
    - Entity Framework Design
    - Entity Framework PostgreSQL


3. Instale [PostgreSQL](https://www.postgresql.org/download/)
4. Instale  [PostgreSQL Get Started](https://www.postgresql.org/)

## Usabilidade

1. Inicie a aplicação com o .NET 
2. A API estará disponível em http://localhost:58494/swagger/index.html


## API Endpoints
A API possui os seguintes endpoints:

```markdown

POST /api/v1/salvar - Rota para registrar um novo planeta

GET /api/v1/buscarClientes - Rota responsável por listar os planetas cadastrados

DELETE /api/v1/deleteCliente/{id_client} - Rota para deletar um planeta por nome

PUT /api/v1/editClientes/{id_planet} - Rota responsável por listar um planeta por ID

GET /api/v1/buscarCliente/{id_planet} - Rota para deletar um planeta

```

**BODY METHOD (POST)**
```json
{
  
    "name": "teste",
    "cnpj": "34234234",
    "endereco": "centro",
    "telefone": "232323"
}
```


## Banco de Dados
O projeto utiliza o [PostgreSQL](https://dev.mysql.com/doc/mysql-getting-started/en/) como banco de dados. Com isso, é necessário realizar a configuração do banco de dados na classe "ClienteDbContext". 

 UseNpgsql("User ID=**seu-id**;Password=**sua-senha**;Host=localhost;Port=5432;Database=**cliente**").

 Para realizar a criação do banco de dados, basta seguir o SQL disponibilizado abaixo:

**Criação de Banco**
 ```sql
 CREATE DATABASE Clientes;
 ```


**Criação de Tabela**
 ```sql

 CREATE TABLE IF NOT EXISTS public."Clientes"
(
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Name" text COLLATE pg_catalog."default",
    "Cnpj" text COLLATE pg_catalog."default",
    "DateCadaster" timestamp without time zone NOT NULL,
    "Endereco" text COLLATE pg_catalog."default",
    "Telefone" text COLLATE pg_catalog."default",
    CONSTRAINT "PK_Clientes" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

 ```


## Contribuição

Sugestões e/ou contribuições são bem-vindas! Se você encontrar qualquer questão ou tenha sugestões de melhorias, por favor, abra uma solicitação pull para o repositório. 


Ao contribuir para este projeto, siga o estilo de código existente, [commit conventions](https://www.conventionalcommits.org/en/v1.0.0/), e envie suas alterações em uma ramificação separada.
