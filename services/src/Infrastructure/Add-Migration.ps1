Set-Variable -Name DB_CONTEXT -Value ApplicationContext
# Should be change the value to add new migration with name
Set-Variable -Name MIGRATION_NAME -Value Version100

dotnet ef migrations add $MIGRATION_NAME -c $DB_CONTEXT -s ..\DataCrawler.Payrix.Api\