# Reservation Project

## Descrição

Este projeto é um pequeno sistema de reservas de que permite aos usuários fazerem reservas de mesas. Ele foi desenvolvido para facilitar o processo de reserva e gerenciamento de serviços. Desenvolvido seguindo os padrões DDD e Arquitetura em camadas.

## Funcionalidades

- Cadastro de usuários
- Login e autenticação com Identity
- Pesquisa de Mesas disponíveis
- Reserva de serviços
- Cancelamento de reservas
- Histórico de reservas
- O primeiro usuário recebe o cargo de Admin, os demais recebem o cargo de User

## Tecnologias Utilizadas

- Linguagem de Programação: C#
- Framework: .NET 8
- Banco de Dados: SQL Server

## Instalação

1. Clone o repositório:

    ```bash
    git clone 
    ```

2. Navegue até o diretório do projeto:

    ```bash
    cd Reservation
    ```

3. Instale as dependências:

    ```bash
    dotnet restore
    ```

4. Rode as Migrations:

    ```bash
    dotnet ef database update -c DataContext -s ../Reservation.API
    dotnet ef database update -c IdentityDataContext -s ../Reservation.API
    ```

5. Inicie o servidor:

    ```bash
    dotnet run
    ```
