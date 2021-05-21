# BelezaNaWebAvaliacao

Essa aplicação tem por objetivo fornecer End Points para Cadastro de Produtos.


# Tecnologias

- Framework <i>net5.0</i>
- Microsoft.EntityFrameworkCore.InMemory <i>(Para gravar os dados de forma simples e em memória)</i>
- xUnit <i>(Utilizado na camada de Testes)</i>
- OpenApi/Swagger <i>(Documentação e testes funcionais da API)</i>

#Arquitetura

O Projeto está organizado em uma arquitetura em camadas separando as responsabilidades de acesso e escopo de cada nível da aplicação.
As camadas e suas responsabilidades:
- Tests <i>Contém o projeto de Testes de Unidade</i>
- Services <i>Destinadas aos serviços que a aplicaão irá fornecer ou utilizar, no caso temos apenas nosso projeto de API.</i>
- Business <i>Contém as regras de negócio dentro da pasta Logic.</i>
- Domain <i>Armazena as classes de modelos para representarmos nossos objetos do Negócio.</i>
- Data <i>Responsável por acesso aos dados.</i>