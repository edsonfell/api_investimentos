
# Documentação para Execução do Projeto da API

  

Este documento fornece instruções passo a passo para configurar e executar o projeto da API no seu ambiente local.


## Requisitos do Sistema
**Ferramentas**: Docker, Docker Compose

## Configuração do Ambiente

Com o código clonado em sua máquina acesse o diretório através de um terminal e execute o seguinte comando:

    docker-compose up -d
    
## Acessando a API:
Após a inicialização, a API estará disponível em http://localhost:8080.

Você pode usar ferramentas como cURL, Postman ou um navegador da web para acessar os endpoints fornecidos pela API.

  

Para saber mais sobre os endpoints e como utilizar a API veja o arquivo de [Documentação da API](API.md)

  

Encerrando a Execução

Para encerrar a execução do projeto, execute o seguinte comando no terminal:

    docker-compose down

Isso encerrará todos os contêineres associados ao projeto.