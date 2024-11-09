# Projeto de Testes com NUnit - Seminário NUnit

Este é um projeto de exemplo para demonstrar o uso do framework de testes unitários NUnit com .NET, incluindo a geração de cobertura de código com o `coverlet` e relatórios em HTML com o `ReportGenerator`. Este projeto também usa GitHub Actions para executar os testes e gerar relatórios automaticamente.

## Estrutura do Projeto

- **Pilha.cs**: Implementação de uma classe `Pilha` com operações básicas de pilha, como `Push`, `Pop`, e `Peek`.
- **PilhaTests.cs**: Testes unitários para verificar o funcionamento correto da classe `Pilha` usando o NUnit.
- **GitHub Actions**: Pipeline de integração contínua configurado para executar testes e gerar relatórios de cobertura de código automaticamente.

## Requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) 6.0 ou superior
- [NUnit](https://nunit.org/) - framework de testes unitários
- [Coverlet](https://github.com/coverlet-coverage/coverlet) - ferramenta de cobertura de código
- [ReportGenerator](https://github.com/danielpalme/ReportGenerator) - ferramenta para converter relatórios de cobertura de código em HTML

## Configuração e Instalação

1. Clone este repositório:
```
git clone https://github.com/seu-usuario/seu-repositorio.git
 ```
 ```
 cd seu-repositorio
 ```

2. Instale as dependências do projeto:
```
dotnet restore
```

3. Adicione o `coverlet.collector` para cobertura de código (execute dentro do diretório do projeto de testes):
```
cd ProjetoPilhaTests
dotnet add package coverlet.collector
```

4. Instale o ReportGenerator como uma ferramenta global:
```
dotnet tool install -g dotnet-reportgenerator-globaltool
```

# Executando os Testes

## Para rodar os testes localmente, use o comando:
```
dotnet test ProjetoPilhaTests/ProjetoPilhaTests.csproj
```

## Para gerar um relatório de cobertura .trx e cobertura de código, use o comando:
```
dotnet test ProjetoPilhaTests/ProjetoPilhaTests.csproj --collect "XPlat Code Coverage" --logger "trx;LogFileName=test_results.trx" --results-directory ./ProjetoPilhaTests/TestResults
```
Após executar este comando, o arquivo de cobertura `coverage.cobertura.xml` será gerado no diretório `./ProjetoPilhaTests/TestResults`.

## Gerando o Relatório de Cobertura em HTML
Para converter o arquivo de cobertura `.xml` em um relatório HTML, execute:
```
reportgenerator "-reports:./ProjetoPilhaTests/TestResults/coverage.cobertura.xml" "-targetdir:./ProjetoPilhaTests/TestResults/HTML" -reporttypes:Html
```
O relatório HTML estará disponível no diretório `./ProjetoPilhaTests/TestResults/HTML`.

## Integração Contínua com GitHub Actions
Este projeto usa GitHub Actions para CI/CD. Sempre que um novo push ou pull request é feito na branch main, o pipeline é executado para:

1. Restaurar dependências.
2. Executar testes e gerar um arquivo de resultados (test_results.trx).
3. Coletar dados de cobertura de código usando coverlet.
4. Converter o relatório de cobertura para HTML usando ReportGenerator.
5. Fazer o upload dos artefatos gerados (test-results.trx e relatório HTML) para revisão.
   
## Visualizando os Relatórios
Após a execução do pipeline, você pode baixar os relatórios gerados como artefatos no GitHub Actions. Eles incluem:
- test-results: Resultados dos testes em formato .trx.
- html-report: Relatório de cobertura em HTML gerado pelo ReportGenerator.



