Claro! Vou adicionar a seção para os scripts das tabelas e gerar um README.md com o conteúdo formatado para o Visual Studio.

### README.md

```markdown
# Meu Projeto ASP.NET Core

## Descrição
Este é um projeto ASP.NET Core para gerenciar clientes, telefones e tipos de telefone. A aplicação inclui funcionalidades CRUD (Criar, Ler, Atualizar, Deletar) para cada entidade e utiliza Entity Framework Core para gerenciamento de banco de dados.

## Funcionalidades
- **Gerenciamento de Clientes:** Adicionar, editar, visualizar e excluir clientes.
- **Gerenciamento de Telefones:** Adicionar, editar, visualizar e excluir telefones, associando-os aos clientes e tipos de telefone.
- **Gerenciamento de Tipos de Telefone:** Adicionar, editar, visualizar e excluir tipos de telefone.
- **Interface de Usuário:** Utiliza Razor Pages para criar uma interface de usuário interativa e responsiva.

## Tecnologias Utilizadas
- **.NET 8.0:** Plataforma para desenvolvimento da aplicação.
- **Entity Framework Core:** ORM para acesso ao banco de dados.
- **SQL Server:** Sistema de gerenciamento de banco de dados.
- **Bootstrap:** Framework CSS para design responsivo.

## Instalação e Execução

1. **Clone o Repositório:**

2. **Navegue para o Diretório do Projeto:**

3. **Instale as Dependências:**

4. **Configure a Conexão com o Banco de Dados:**
    Edite o arquivo `appsettings.json` para definir a string de conexão com o banco de dados. Exemplo:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MeuProjetoDb;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
    ```

5. **Crie o Banco de Dados:**
    ```bash
    dotnet ef database update
    ```

6. **Execute a Aplicação:**
    ```bash
    dotnet run
    ```
    A aplicação estará disponível em [http://localhost:5000](http://localhost:5000) ou [https://localhost:5001](https://localhost:5001).

## Estrutura do Projeto
- **Controllers:** Contém os controladores MVC para gerenciar as operações CRUD.
- **Models:** Contém as classes de modelo que representam as entidades do banco de dados.
- **Views:** Contém as páginas Razor usadas para renderizar a interface do usuário.
- **Data:** Contém o contexto do banco de dados e a configuração de EF Core.

## Scripts de Banco de Dados
Os scripts para criar as tabelas do banco de dados estão localizados na pasta `Tabelas`. Aqui estão os scripts para criar as três tabelas:

### Script para a Tabela `Clientes`

```sql
CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    DataNascimento DATE NOT NULL,
    DataCadastro DATETIME DEFAULT GETDATE()
);
```

### Script para a Tabela `Telefones`

```sql
CREATE TABLE Telefones (
    Id INT PRIMARY KEY IDENTITY,
    CodigoCliente INT NOT NULL,
    NumeroTelefone NVARCHAR(20) NOT NULL,
    CodigoTipoTelefone INT NOT NULL,
    Operador NVARCHAR(50) NOT NULL,
    Ativo BIT NOT NULL,
    DataInsercao DATETIME DEFAULT GETDATE(),
    UsuarioInsercao NVARCHAR(100) NOT NULL,
    FOREIGN KEY (CodigoCliente) REFERENCES Clientes(Id),
    FOREIGN KEY (CodigoTipoTelefone) REFERENCES TiposTelefone(Id)
);
```

### Script para a Tabela `TiposTelefone`

```sql
CREATE TABLE TiposTelefone (
    Id INT PRIMARY KEY IDENTITY,
    Descricao NVARCHAR(50) NOT NULL
);
```

**Para gerar as tabelas no banco de dados:**


1. Execute os scripts SQL no seu gerenciador de banco de dados para criar as tabelas.

## Contribuições
Se você deseja contribuir para o projeto, siga estas etapas:
1. Faça um fork do repositório.
2. Crie uma branch para suas alterações.
3. Faça commit das suas alterações.
4. Envie um pull request com uma descrição detalhada das mudanças.

## Licença
Este projeto é licenciado sob a MIT License.

## Contato
Para mais informações, entre em contato com:
Ícaro Nobre - nobreicaro@gmail.com
```

