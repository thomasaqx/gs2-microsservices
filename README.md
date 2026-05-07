# Prompt API

API em C# para gerenciamento de Prompts, utilizando Dapper e arquitetura organizada em camadas (Model, Repository, Service e Controller).

---

## Etapas do Projeto

### Etapa 1 – Modelagem do Domínio
- Criação do projeto base da API;
- Modelagem da classe Prompt (entidade principal do domínio);
- Configuração da conexão com o banco de dados;
- Implementação do Dapper para acesso aos dados;
- **Branch:** feature/modelagem-dominio.

---

### Etapa 2 – Implementação do Core
- Criação da PromptController com os endpoints principais;
- Criação da camada Service para regras de negócio;
- Injeção de dependência entre Controller -> Service -> Repository;
- Swagger configurado para documentação e teste da API;
- **Branch:** feature/implementacao-core.

---

### Etapa 3 – Validações e Melhorias
- Implementação de tratamento global de exceções via middleware (classe - ErrorMiddleware).
- Atualização e consolidação do README.md com todas as etapas.
- Manutenção do Swagger para testes de endpoints.
- **Branch:** feature/validacoes-melhorias.

---

## Tecnologias Utilizadas
- C#
- Dapper
- Swagger
- Git e GitHub
- Visual Studio Code

---

## Como Executar o Projeto

# Clonar o repositório
https://github.com/thomasaqx/gs2-microsservices

# Acessar a pasta do projeto
cd PromptApi

# Restaurar as dependências
dotnet restore

# Executar a aplicação
dotnet run

# Entre no Swagger pelo navegador
http://localhost:5234/swagger/index.html


