# Regras pacientes

## Atributor "Cor"

* Branco - 0
* Negro - 1
* Pardo - 2
* Indigena - 3
* Naoespecificado - 4

# Regras médicos

## Tipos de médico

* Médico comum - 0
* Docente - 1
* Residente - 2


# Como usar Migrações

Migrações é um recurso do Enity Framework core
que atualiza o banco de dados para mantê-lo em sincronia com o modelo do de dados da aplicação

Para criar uma migração utiliza-se o seguinte comando:

    No PM:
    >> Add-Migration <nome_da_migration> -Project Hospital.Infra.Data -StartupProject Hospital.Application -Vertbose

    No CLI:
    >> dotnet ef migrations add <nome_da_migration> -Project Hospital.Infra.Data -StartupProject Hospital.Application -Verbose

    Notas:
    -Project é o projeto onde está o DbContext
    -StartupProject é o projeto onde está a configuração da aplicação

Para atualizar o banco de dados usando a migração utiliza-se o seguinte comando:

    No PM:
    >> Update-Database

    No CLI:
    >> dotnet ef database update

Para remover uma migração utiliza-se o comando:

    No PM:
    >> Remove-Migration

    No CLI:
    >> dotnet ef migrations remove

Para gerar o script do banco de dados utiliza-se o comando:

    No PM:
    >> Script-Migration

    No CLI:
    >> dotnet ef migrations script

Links uteis:
https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/
https://docs.microsoft.com/pt-br/ef/core/miscellaneous/cli/dotnet