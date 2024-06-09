# Sobre a API

A ideia dessa API é simular um sistema de investimento em suas funcionalidades mais básicas, permitindo ações como:

 - Visualizar usuários cadastrados no sistema. (Essa API não permite a criação de usuários pois não fazia parte dos requisitos recebidos. Na inicialização dos containers dessa aplicação serão criados automaticamente 3 usuários no banco de dados)
 - Realizar a gestão (Criação, Atualização, listagem e deleção) de produtos financeiros.
 - Realizar a gestão compra, venda e listagem de investimentos de um usuário específico

Para realizar essas ações será necessário interagir com as rotas da API de acordo com a forma como foram definidas.

> Caso desejado a documentação Swagger da API pode ser acessada via
> http://localhost:8080/swagger

# Rotas da API
**Todas as rotas podem ser acessadas a partir da URL base http://localhost:8080/**

## Usuario
**Descrição:**
Esta rota gerencia operações relacionadas aos usuários do sistema.

**Endpoints:**

***GET /v1/usuario***
Descrição: Retorna uma lista de todos os usuários cadastrados.
Método HTTP: GET
Parâmetros: Nenhum
Retorno: Uma lista de objetos de usuário.

***GET /v1/usuario/{id}***
Descrição: Retorna informações de um usuário específico com base no ID fornecido.
Método HTTP: GET
Parâmetros: id (Guid) - ID do usuário desejado.
Retorno: Objeto de usuário correspondente ao ID fornecido, se encontrado.

## Gestão Produto
**Descrição:**
Este controlador gerencia operações relacionadas aos produtos financeiros disponíveis no sistema.

Endpoints:

***GET /v1/gestao-produto***
Descrição: Retorna uma lista de todos os produtos financeiros cadastrados.
Método HTTP: GET
Parâmetros: Nenhum
Retorno: Uma lista de objetos de produtos financeiros.

***GET /v1/gestao-produto/{id}***
Descrição: Retorna informações de um produto financeiro específico com base no ID fornecido.
Método HTTP: GET
Parâmetros: id (Guid) - ID do produto financeiro desejado.
Retorno: Objeto de produto financeiro correspondente ao ID fornecido, se encontrado.

***POST /v1/gestao-produto***
Descrição: Cria um novo registro de produto financeiro.
Método HTTP: POST
Corpo da Requisição: Objeto ProdutoFinanceiroViewModel contendo informações do produto financeiro a ser criado.
Retorno: O produto financeiro criado.

***PUT /v1/gestao-produto/{id}***
Descrição: Atualiza um produto financeiro existente.
Método HTTP: PUT
Corpo da Requisição: Objeto ProdutoFinanceiroViewModel contendo informações do produto financeiro a ser atualizado.
Parâmetros: id (Guid) - ID do produto financeiro a ser atualizado.
Retorno: O produto financeiro atualizado.

***DELETE /v1/gestao-produto/{id}***
Descrição: Remove um produto financeiro específico.
Método HTTP: DELETE
Parâmetros: id (Guid) - ID do produto financeiro a ser removido.
Retorno: Status de sucesso se o produto financeiro for removido com êxito.
Essa documentação fornece uma visão geral clara de cada controlador e seus endpoints, facilitando o entendimento e uso da sua API.

## Controle Investimento
**Descrição:**
Esta rota gerencia operações relacionadas aos investimentos financeiros dos usuários.

**Endpoints:**

***GET /v1/controle-investimento/{userId}***
Descrição: Retorna detalhes dos investimentos de um usuário específico.
Método HTTP: GET
Parâmetros: userId (Guid) - ID do usuário cujos investimentos estão sendo consultados.
Retorno: Uma lista de objetos de investimento detalhados.

***GET /v1/controle-investimento/{userId}/{idInvestimento}***
Descrição: Retorna detalhes de um investimento específico de um usuário.
Método HTTP: GET
Parâmetros: userId (Guid) - ID do usuário dono do investimento. idInvestimento (Guid) - ID do investimento desejado.
Retorno: Objeto de investimento detalhado correspondente ao ID fornecido, se encontrado.

***POST /v1/controle-investimento***
Descrição: **Cria** um novo registro de investimento para um usuário. Se o usuário já possuir quotas de um investimento específico e deseja incluir mais a o método PUT dessa mesma rota deve ser utilizado.  
Método HTTP: POST
Corpo da Requisição: Objeto PostControleInvestimentoViewModel contendo informações do investimento.
Retorno: O investimento criado.

***PUT /v1/controle-investimento***
Descrição: **Atualiza** um investimento existente para um usuário. Essa rota deve ser utilizada para compra/venda de um investimento já existente. Existem algumas validações para não permitir "vender" mais cotas de um investimento do que o usuário possui previamente. Caso o usuário deseje vender todas as quotas de um investimento a rota DELETE deve ser utilizada.
Método HTTP: PUT
Corpo da Requisição: Objeto PutControleInvestimentoViewModel contendo informações do investimento a ser atualizado.
Retorno: O investimento atualizado.

***DELETE /v1/controle-investimento/{userId}/{idInvestimento}***
Descrição: Remove um investimento específico de um usuário.
Método HTTP: DELETE
Parâmetros: userId (Guid) - ID do usuário dono do investimento. idInvestimento (Guid) - ID do investimento a ser removido.
Retorno: Status de sucesso se o investimento for removido com êxito.



 
