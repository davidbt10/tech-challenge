#Tech Challenge

              O Tech Challenge desta fase é o desenvolvimento de uma API para um portal de investimentos. 

              Passo a Passo:

              1 - Será necessário criar uma instância de banco de dados SQL-Server, utilizando o comando abaixo no docker:
                docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=SqlServer2019!' -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2019-latest

              2 - Depois será necessário abrir a aba "Package Manager Console" no Visual Studio, e executar os comandos para executar as Migrations na base de dados
                  Obs.: a ConnectionString já está apontada para localhost
