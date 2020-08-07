# Central de Erros

## Objetivo
Em projetos modernos é cada vez mais comum o uso de arquiteturas baseadas em serviços ou microsserviços. Nestes ambientes complexos, erros podem surgir em diferentes camadas da aplicação (backend, frontend, mobile, desktop) e mesmo em serviços distintos. Desta forma, é muito importante que os desenvolvedores possam centralizar todos os registros de erros em um local, de onde podem monitorar e tomar decisões mais acertadas. Neste projeto vamos implementar um sistema para centralizar registros de erros de aplicações.

## Requisitos do projeto desafio final Backend - API:
- criar endpoints para serem usados pelo frontend da aplicação
- criar um endpoint que será usado para gravar os logs de erro em um banco de dados relacional
- a API deve ser segura, permitindo acesso apenas com um token de autenticação válido

## Arquitetura escolhida:
- Nosso squad escolheu a [Arquitetura DDD](https://www.devmedia.com.br/introducao-ao-ddd-em-net/32724) pois foi a mais utilizada durante a Aceleração C# Women Codenation patrocinado pela ClearSale.
- Para a integração com o Banco de Dados escolhemos o modelo [Database First](https://docs.microsoft.com/pt-br/ef/ef6/modeling/designer/workflows/database-first).
- Diagrama de Entidade e Relacionamento:

![schema](https://user-images.githubusercontent.com/60229135/89474652-9aa9be00-d75c-11ea-868f-e07cdc002413.jpg)

## Tecnologias utilizadas:
- [ASP.NET Core](https://docs.microsoft.com/pt-br/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-3.1)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-2019)
- [Auto Mapper](https://github.com/AutoMapper/AutoMapper)
- [Swagger](https://swagger.io/)
- [ASP.NET Identity](https://docs.microsoft.com/pt-br/aspnet/identity/overview/getting-started/introduction-to-aspnet-identity)
- [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/)
- [Microsoft Azure](https://azure.microsoft.com/pt-br/)

## [Deploy da Aplicação](https://squad3.azurewebsites.net/swagger/index.html)

## Sobre organização e desenvolvimento:
- Nosso Squad adaptou conceitos da [Metodologia Ágil e Scrum](https://blog.trello.com/br/scrum-metodologia-agil) organizando Sprints semanais para definir as tarefas de cada integrante, onde definiamos prioridades e juntas fazíamos as correções necessários para o projeto.
- A documentação foi feita utilizando um quadro do [Trello](https://trello.com/pt-BR) e as tarefas definidas em cards.
- Como estávamos todas trabalhando remotamente, as Sprints foram feitas pelo [Google Meet](https://apps.google.com/meet/)

## [Slides da Apresentação](https://drive.google.com/file/d/1QZnFJi7mXGl-O7iR4_H8F6usjl361jSo/view?usp=sharing)

## Integrantes do Squad 3:
- Edna Oliveira | [@eaoliveira](https://github.com/eaoliveira)
- Érica Nogueira | [@EricaNogueiraMendes](https://github.com/EricaNogueiraMendes)
- Tamires Cunha | [@Tamrs](https://github.com/Tamrs)
- Danielly Primo | [@dan-primo](https://github.com/dan-primo)

## Agradecimentos:
- Codenation | [@codenation.dev](https://github.com/codenation-dev) pelo curso/aceleração em C#, por acreditarem em educação e acelerarem nossas carreiras.
- ClearSale | [@ClearSale](https://github.com/ClearSale) a empresa patrocinadora da nossa aceleração, agradecemos por investir em inclusão de mais mulheres em tech.
- A nossa muito querida professora Alessandra | [@AlessandraSoaresdosSantos](https://github.com/AlessandraSoaresdosSantos), que nunca deixa ninguém para trás.
- A também nossa atenciosa e super querida Ingrid | [@ingrid139](https://github.com/ingrid139), que nos mentorou e deu suporte durante o curso.
- E um agradecimento também para a mega querida Djovana | [@djovanaboeing1](https://github.com/djovanaboeing1), que nunca nos deixou desamparadas.
