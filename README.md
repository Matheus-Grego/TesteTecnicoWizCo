# 🛒 GerenciadorPedidos

API RESTful para gerenciamento de pedidos, desenvolvida como teste técnico. Construída com **.NET 8**, seguindo os princípios de **Clean Architecture** e os padrões **CQRS** e **Mediator**.

---

## 📐 Arquitetura

O projeto é dividido em quatro camadas:

```
TesteTecnicoWizCo/
├── GerenciadorPedidos.API/            # Camada de apresentação (Controllers, Middleware)
├── GerenciadorPedidos.Application/   # Casos de uso (Commands, Queries, DTOs, Validators)
├── GerenciadorPedidos.Domain/        # Entidades, enums e interfaces de repositório
├── GerenciadorPedidos.Infrastructure/# Acesso a dados (EF Core, PostgreSQL)
└── GerenciadorPedidos.UnitTests/     # Testes unitários (xUnit + Moq)
```

### Fluxo de uma requisição

```
HTTP Request
    │
    ▼
PedidosController   (API)
    │  envia Command/Query via IMediator
    ▼
Handler             (Application)
    │  usa IPedidoRepository
    ▼
PedidoRepository    (Infrastructure)
    │  acessa banco via EF Core
    ▼
PostgreSQL
```

---

## 🧩 Tecnologias

| Tecnologia | Uso |
|---|---|
| .NET 8 | Framework principal |
| ASP.NET Core | Web API |
| Entity Framework Core | ORM |
| PostgreSQL | Banco de dados |
| MediatR | Padrão CQRS / Mediator |
| FluentValidation | Validação de entrada |
| xUnit | Testes unitários |
| Moq | Mocks para testes |
| Docker | Containerização |
| Swagger | Documentação da API |

---

## 🗂️ Domínio

### Entidades

**`BaseEntity`** — base para todas as entidades:
- `Id` (Guid) — gerado automaticamente
- `DataCriacao` (DateTime) — preenchida no momento da criação
- `DataAtualizacao` (DateTime?) — atualizada em modificações
- `IsDeleted` (bool) — soft delete via método `Deletar()`

**`Pedido`** — representa um pedido:
- `ClienteNome` — nome do cliente
- `Status` — `Novo`, `Pago` ou `Cancelado`
- `ValorTotal` — calculado a partir dos itens
- `Itens` — coleção de `ItemPedido`
- Métodos: `CancelarPedido()`, `PagarPedido()`

**`ItemPedido`** — item de um pedido:
- `PedidoId` — FK para o pedido
- `ProdutoNome` — nome do produto (máx. 150 chars)
- `Quantidade` — quantidade do item
- `ValorUnitario` — preço unitário

### Status do Pedido

```
Novo (0)  ──────► Cancelado (2)
                     
Novo (0)  ──────► Pago (1)
```

> Somente pedidos com status `Novo` podem ser cancelados.

---

## 📡 Endpoints

Base URL: `/pedidos`

| Método | Rota | Descrição |
|---|---|---|
| `GET` | `/pedidos` | Lista todos os pedidos com filtros opcionais |
| `GET` | `/pedidos/{id}` | Busca um pedido pelo ID |
| `POST` | `/pedidos` | Cria um novo pedido |
| `PUT` | `/pedidos/{id}/cancelar` | Cancela um pedido |
| `DELETE` | `/pedidos/{id}` | Remove um pedido (soft delete) |

### `GET /pedidos` — parâmetros de query

| Parâmetro | Tipo | Descrição |
|---|---|---|
| `status` | string | Filtra por status: `novo`, `pago` ou `cancelado` |
| `page` | int | Número da página (paginação) |
| `size` | int | Itens por página (paginação) |

### `POST /pedidos` — corpo da requisição

```json
{
  "clienteNome": "João Silva",
  "itemsPedido": [
    {
      "produtoNome": "Camiseta",
      "quantidade": 2,
      "valorUnitario": 49.90
    }
  ]
}
```

#### Regras de validação (FluentValidation)

- `clienteNome`: obrigatório, máx. 100 caracteres
- `itemsPedido`: obrigatório, deve ter pelo menos 1 item
- Cada item: `produtoNome` obrigatório (máx. 100 chars), `quantidade > 0`, `valorUnitario > 0`

### Respostas padrão

Todos os endpoints retornam um objeto `Result`:

```json
{
  "isSuccess": true,
  "message": "",
  "data": { }
}
```

Em caso de erro, `isSuccess` é `false` e `message` descreve o problema. O HTTP status code será `400 Bad Request`.

---

## 🚀 Como executar

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8)
- [Docker](https://www.docker.com/) e Docker Compose

### 1. Clonar o repositório

```bash
git clone https://github.com/Matheus-Grego/TesteTecnicoWizCo.git
cd TesteTecnicoWizCo
```

### 2. Configurar a connection string

Edite `GerenciadorPedidos.API/appsettings.json` com os dados do seu banco PostgreSQL:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=gerenciador_pedidos;Username=postgres;Password=sua_senha"
  }
}
```

### 3. Executar com Docker

```bash
docker compose up --build
```

A API ficará disponível em `http://localhost:8080`.

### 4. Executar localmente (sem Docker)

```bash
cd GerenciadorPedidos.API
dotnet run
```

A interface do Swagger estará em `http://localhost:<porta>/swagger` quando o ambiente for `Development`.

---

## 🧪 Testes

Execute os testes unitários com:

```bash
dotnet test
```

Os testes cobrem o `CancelPedidoHandler`, verificando:
- Cancelamento bem-sucedido quando o pedido existe e está com status `Novo`
- Retorno de `Failure` quando o pedido não é encontrado

---

## 📁 Estrutura detalhada

```
GerenciadorPedidos.Application/
├── Commands/
│   ├── CancelPedido/   # CancelPedidoCommand + Handler
│   ├── DeletePedido/   # DeletePedidoCommand + Handler
│   └── InsertPedido/   # InsertPedidoCommand + Handler
├── Queries/
│   ├── GetAllPedidos/  # GetAllPedidosQuery + Handler
│   └── GetPedidoById/  # GetPedidoByIdQuery + Handler
├── DTOs/               # PedidoDTO, ItemPedidoDTO, InsertItemPedidoDTO
├── Validators/         # InsertPedidoValidator (FluentValidation)
└── Common/Result/      # Result<T> — envelope de resposta
```

---

## 📝 Observações

- O projeto usa **soft delete**: registros deletados têm `IsDeleted = true` e são filtrados nas consultas.
- O `ValorTotal` do pedido é calculado automaticamente na criação, somando `quantidade × valorUnitario` de cada item.
- O tratamento global de exceções é feito pelo `APIExceptionHandler` registrado na camada de API.
