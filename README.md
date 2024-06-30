# API de simulação do funcionamento de um caixa eletrônico.

## Descrição do Projeto
A ApiCaixaEletronico é uma API RESTful desenvolvida para simular o funcionamento de um caixa eletrônico. O principal objetivo desta API é fornecer a quantidade mínima de cédulas necessárias para atender um valor de saque solicitado pelo usuário.


## Arquitetura Utilizada
A arquitetura do projeto segue os princípios de uma API RESTful.


## Tecnologias
- ASP.NET Core 8.0
- C#


## Pré-requisitos
- .NET Core SDK 8.0 ou superior

## Como Executar

1. **Clonar o repositório**:
    ```bash
    git clone https://github.com/Tonussi01/ApiCaixaEletronico.git
    ```

2. **Restaurar dependências**:
    ```bash
    dotnet restore
    ```

3. **Compilar o projeto**:
    ```bash
    dotnet build
    ```

4. **Executar o projeto**:
    ```bash
    dotnet run --project ApiCaixaEletronico
    ```

5. **Acessar a documentação Swagger**:
    ```bash
    https://localhost:{porta}/swagger
    ```
 

## Formato do Endpoint
URL: /api/saque

Método: POST

Entrada (JSON):

    {  "valor": 380 }
    

Saída (JSON):

```bash
{ 
  "100": 3,
  "50": 1,
  "20": 1,
  "10": 1,
  "5": 0,
  "2": 0 
}
    
