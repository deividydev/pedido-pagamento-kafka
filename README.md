# pedido-pagamento-kafka

Sistema simples de pedidos utilizando Kafka, arquitetura limpa e CQRS. O projeto demonstra a comunicação assíncrona entre microsserviços, onde o pagamento de um pedido dispara eventos para envio de e-mail.

## Tecnologias

- .NET 9
- Apache Kafka
- MediatR
- Clean Architecture
- Docker (Kafka e Zookeeper via Docker Compose)

## Como rodar localmente

### 1. Clone o repositório

```bash
git clone <URL-do-repositório>
cd pedido-pagamento-kafka
```

## 2. Inicie Kafka e Zookeeper via Docker Compose
No diretório do projeto (onde está o arquivo docker-compose.yml), execute:
```bash
docker-compose up -d
```

## 3. Rode a API localmente
No terminal, execute os seguintes comandos para restaurar pacotes, compilar e rodar a API:
```bash
dotnet restore
dotnet build
dotnet run
```

## Autor

Desenvolvido por Deividy Henrique Alves Pinheiro.
