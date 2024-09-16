# ProspAI - Versão .NET

**ProspAI** é uma aplicação de inteligência artificial desenvolvida para otimizar estratégias de vendas através da análise de dados de clientes. A aplicação oferece uma API RESTful robusta e uma interface MVC baseada em ASP.NET Core, facilitando a navegação e a utilização dos recursos disponíveis.


## Índice

1. [Visão Geral do Projeto](#visão-geral-do-projeto)
2. [Arquitetura](#arquitetura)
3. [Recursos Principais](#recursos-principais)
4. [Tecnologias Utilizadas](#tecnologias-utilizadas)
5. [Padrões de Projeto Implementados](#padrões-de-projeto-implementados)
6. [Endpoints da API](#endpoints-da-api)
7. [Funcionalidades da Interface MVC](#funcionalidades-da-interface-mvc)
8. [Instalação e Configuração](#instalação-e-configuração)
9. [Como Contribuir](#como-contribuir)
10. [Licença](#licença)
11. [Autores](#autores)

## Visão Geral do Projeto

**ProspAI** é uma plataforma que combina inteligência artificial e análise de dados para melhorar a tomada de decisão em vendas. Através da integração com fontes de dados externas, como Reclame Aqui e Procon, a aplicação consegue analisar feedbacks de clientes e oferecer predições e relatórios detalhados para otimização de estratégias de vendas.

## Arquitetura

A aplicação ProspAI é composta de duas partes principais:

1. **API RESTful**: Construída utilizando ASP.NET Core, oferecendo endpoints para operações CRUD sobre funcionários, reclamações, desempenhos, entre outros.
   
2. **Interface MVC**: Baseada em Razor Pages, a interface MVC proporciona uma experiência de usuário intuitiva e permite a visualização e manipulação dos dados de forma amigável.

A aplicação utiliza os padrões de Repositório e Serviço para manter uma separação clara de responsabilidades e facilitar a realização de testes unitários.

## Recursos Principais

- **Gestão de Funcionários**: Criação, edição, visualização e remoção de funcionários.
- **Gestão de Reclamações**: Manipulação de reclamações associadas a funcionários.
- **Análise de Desempenho**: Geração de relatórios de desempenho com base nos dados das reclamações e respostas dos funcionários.
- **Automação de Estratégias de Vendas**: Definição e implementação de estratégias automáticas para otimização de vendas.
- **Gestão de Usuários**: Controle de acesso e gerenciamento de usuários da plataforma.

## Tecnologias Utilizadas

- .NET 6
- ASP.NET Core Web API e MVC
- Entity Framework Core com integração ao Oracle
- AutoMapper para mapeamento de objetos
- Swagger/OpenAPI para documentação da API
- JavaScript e Bootstrap para interatividade e design responsivo

## Padrões de Projeto Implementados

- **DTO (Data Transfer Object)**: Utilizados para transferir dados entre a camada de serviço e a camada de apresentação.
- **Padrão de Repositório**: Fornece uma API limpa para a lógica de acesso a dados.
- **Padrão de Serviço**: Separa a lógica de negócios dos controladores e repositórios.
- **Injeção de Dependência**: Implementada para gerenciar dependências e promover testabilidade.

## Endpoints da API

Abaixo está a lista de principais endpoints da API RESTful disponíveis:

### Funcionários (/api/funcionarios)
- `GET /api/funcionarios` - Retorna todos os funcionários.
- `GET /api/funcionarios/{id}` - Retorna um funcionário específico por ID.
- `POST /api/funcionarios` - Cria um novo funcionário.
- `PUT /api/funcionarios/{id}` - Atualiza um funcionário existente.
- `DELETE /api/funcionarios/{id}` - Deleta um funcionário.

### Reclamações (/api/reclamacoes)
- `GET /api/reclamacoes` - Retorna todas as reclamações.
- `GET /api/reclamacoes/{id}` - Retorna uma reclamação específica por ID.
- `POST /api/reclamacoes` - Cria uma nova reclamação.
- `PUT /api/reclamacoes/{id}` - Atualiza uma reclamação existente.
- `DELETE /api/reclamacoes/{id}` - Deleta uma reclamação.

### Desempenho (/api/desempenho)
- `GET /api/desempenho` - Retorna todos os registros de desempenho.
- `GET /api/desempenho/{id}` - Retorna um registro de desempenho específico por ID.
- `POST /api/desempenho` - Cria um novo registro de desempenho.
- `PUT /api/desempenho/{id}` - Atualiza um registro de desempenho existente.
- `DELETE /api/desempenho/{id}` - Deleta um registro de desempenho.

### Documentação Swagger
Para testar e visualizar a documentação dos endpoints da API, acesse:

- **Ambiente Local:** [http://localhost:5000/swagger](http://localhost:5000/swagger)


## Instalação e Configuração

1. **Clone o Repositório:**
   ```bash
   git clone https://github.com/seu-usuario/prospai-dotnet.git
   cd prospai-dotnet
   ```

2. **Configure o Banco de Dados:**
   - A aplicação utiliza Oracle. Atualize as configurações do banco de dados no arquivo `appsettings.json` conforme necessário.

3. **Execute a Aplicação:**
   - Utilize o .NET CLI ou qualquer IDE (como Visual Studio ou Rider) para compilar e executar o projeto:
   ```bash
   dotnet run
   ```

4. **Acesse a Aplicação:**
   - Acesse a aplicação através do navegador: [http://localhost:5000/api/funcionarios](http://localhost:5000/api/funcionarios).

## Como Contribuir

1. **Fork o Projeto**
2. **Crie um Branch de Funcionalidade**
   ```bash
   git checkout -b nova-funcionalidade
   ```
3. **Commit suas Alterações**
   ```bash
   git commit -m 'Adiciona nova funcionalidade'
   ```
4. **Envie o Branch**
   ```bash
   git push origin nova-funcionalidade
   ```
5. **Abra um Pull Request**

## Licença

Este projeto é licenciado sob os termos da MIT License.

## Autores

Este projeto foi desenvolvido por:

- **AGATHA PIRES** – RM552247 – (2TDSPH)
- **DAVID BRYAN VIANA** – RM551236 – (2TDSPM)
- **GABRIEL LIMA** – RM99743 – (2TDSPM)
- **GIOVANNA ALVAREZ** – RM98892 – (2TDSPM)
- **MURILO MATOS** – RM552525 – (2TDSPM)

---

Sinta-se à vontade para contribuir com melhorias e novas funcionalidades para o ProspAI!
