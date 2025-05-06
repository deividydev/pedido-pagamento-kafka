# pedido-pagamento-kafka

Sistema simples de pedidos utilizando Kafka, arquitetura limpa e CQRS. O projeto demonstra a comunicação assíncrona entre microsserviços, onde o pagamento de um pedido dispara eventos para envio de e-mail.

## Tecnologias

- .NET 8 (ou versão mais recente)
- Apache Kafka
- MediatR
- Clean Architecture
- Docker (para Kafka e Zookeeper)

## Rodando Localmente

1. Clone o repositório.
2. Execute o Kafka e Zookeeper com o Docker:
    ```bash
    docker-compose up -d
    ```
3. Execute o projeto no Visual Studio ou via CLI:
    ```bash
    dotnet run
    ```
