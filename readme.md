# App Gerenciamento de estoque

-ainda em desenvolvimento-

## Download e execução do sistema

É necessario baixar o repositório `ProdutoEstoqueApi` e `ControleEstoqueApp`.
Depois de baixado os arquivos, primeiramente deve-se editar o arquivo
`appSettings.json` na solução `ProdutoEstoqueApi`, substituindo os `*` pelo servidor, user id
e senha e assim realizando a conexão com o banco de dados Sql Server.

Após isso, deve-se iniciar a api.


Com a api em execução, pode-se executar o app.



## Sobre

Esta é uma aplicação CRUD, desenvolvida com C# e .Net.
A api foi criada com ações `GET`, `POST`, `PUT` e `DELETE` para as entidades produto, estoque e lojas.

Já o app foi criado com razor pages, realizando as ações `GET`, `POST`, `PUT` e `DELETE` com uma interface.

## Observações

1. As ações da tabela estoque não estão funcionais, pois foram feitas alterações no
decorrer do desenvolvimento que afetaram no funcionamento da mesma.
2. A autenticação por JWT também não foi implementada (ainda), devido a falta de tempo hábil.
3. Testes unitários também não foram realizados, por falta de tempo hábil.
