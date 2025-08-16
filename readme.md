# Minimal API - Sistema de Gestão de Veículos e Administradores

## 📋 Descrição

Este projeto é uma **Minimal API** desenvolvida em **.NET 9** que implementa um sistema de gestão de veículos e administradores. A API oferece funcionalidades completas de CRUD para ambas as entidades, com autenticação JWT e autorização baseada em perfis de usuário.

## 🚀 Tecnologias Utilizadas

- **.NET 9**
- **Entity Framework Core 9.0.7**
- **MySQL** (via Pomelo.EntityFrameworkCore.MySql)
- **JWT Bearer Authentication**
- **Swagger/OpenAPI** para documentação
- **MSTest** para testes unitários

## 🏗️ Arquitetura

O projeto segue uma arquitetura em camadas com separação clara de responsabilidades:

```
📁 Api/
├── 📁 Dominio/
│   ├── 📁 DTOs/           # Data Transfer Objects
│   ├── 📁 Entidades/      # Entidades do domínio
│   ├── 📁 Enuns/          # Enumerações
│   ├── 📁 Interfaces/     # Contratos de serviços
│   ├── 📁 ModelViews/     # Modelos de visualização
│   └── 📁 Servicos/       # Lógica de negócio
├── 📁 Infraestrutura/
│   └── 📁 Db/             # Contexto do banco de dados
├── 📁 Migrations/         # Migrações do Entity Framework
└── 📁 Properties/         # Configurações de inicialização
```

## 🛠️ Funcionalidades

### 🔐 Autenticação e Autorização

- Sistema de login com JWT
- Perfis de usuário: **Administrador (Adm)** e **Editor**
- Controle de acesso baseado em roles

### 👥 Gestão de Administradores

- **GET** `/administradores` - Listar administradores (paginado)
- **GET** `/administradores/{id}` - Buscar por ID
- **POST** `/administradores` - Criar novo administrador
- **POST** `/administradores/login` - Autenticação

### 🚗 Gestão de Veículos

- **GET** `/veiculos` - Listar veículos (com filtros por nome/marca e paginação)
- **GET** `/veiculos/{id}` - Buscar por ID
- **POST** `/veiculos` - Criar novo veículo
- **PUT** `/veiculos/{id}` - Atualizar veículo
- **DELETE** `/veiculos/{id}` - Remover veículo

## 📊 Modelo de Dados

### Administrador

```csharp
{
    "id": 1,
    "email": "admin@teste.com",
    "senha": "123456",
    "perfil": "Adm"
}
```

### Veículo

```csharp
{
    "id": 1,
    "nome": "Civic",
    "marca": "Honda",
    "ano": 2020
}
```

## ⚙️ Configuração e Execução

### Pré-requisitos

- .NET 9 SDK
- MySQL Server
- Visual Studio ou VS Code

### 1. Clone o repositório

```bash
git clone https://github.com/Guitor-92/minimal-api.git
cd minimal-api
```

### 2. Configure a string de conexão

Edite o arquivo `appsettings.json` na pasta `Api/`:

```json
{
  "ConnectionStrings": {
    "MySql": "Server=localhost;Database=minimal_api;Uid=root;Pwd=sua_senha;"
  },
  "Jwt": "sua_chave_secreta_jwt_aqui"
}
```

### 3. Execute as migrações

```bash
cd Api
dotnet ef database update
```

### 4. Execute a aplicação

```bash
dotnet run
```

A API estará disponível em:

- **HTTP**: `http://localhost:5000`
- **HTTPS**: `https://localhost:5001`
- **Swagger UI**: `https://localhost:5001/swagger`

## 🧪 Testes

O projeto inclui uma suíte completa de testes unitários para:

- Entidades (Administrador e Veículo)
- Serviços (AdministradorServico e VeiculoServico)
- Requests/Endpoints

### Executar os testes

```bash
cd Test
dotnet test
```

## 🔒 Autenticação

### Login

Para autenticar, faça uma requisição POST para `/administradores/login`:

```json
{
  "email": "administrador@teste.com",
  "senha": "123456"
}
```

Resposta:

```json
{
  "email": "administrador@teste.com",
  "perfil": "Adm",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

### Usar o token

Inclua o token JWT no header `Authorization` das requisições:

```
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

## 📋 Validações

### Veículos

- **Nome**: Obrigatório, não pode estar vazio
- **Marca**: Obrigatório, não pode estar em branco
- **Ano**: Deve ser superior a 1950

### Administradores

- **Email**: Obrigatório, formato de email válido
- **Senha**: Obrigatório
- **Perfil**: Deve ser "Adm" ou "Editor"

## 🎯 Permissões por Perfil

| Ação                      | Administrador | Editor |
| ------------------------- | ------------- | ------ |
| Listar veículos           | ✅            | ✅     |
| Ver detalhes do veículo   | ✅            | ✅     |
| Criar veículo             | ✅            | ✅     |
| Editar veículo            | ✅            | ❌     |
| Excluir veículo           | ✅            | ❌     |
| Gerenciar administradores | ✅            | ❌     |

## 📈 Paginação

A API suporta paginação nos endpoints de listagem:

- **Parâmetro**: `pagina` (padrão: 1)
- **Itens por página**: 10

Exemplo: `GET /veiculos?pagina=2&nome=civic&marca=honda`

## 🤝 Contribuição

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 👨‍💻 Autor

**Vitor Guitor**

- GitHub: [@Guitor-92](https://github.com/Guitor-92)

---

⭐ Se este projeto foi útil para você, considere dar uma estrela no repositório!
