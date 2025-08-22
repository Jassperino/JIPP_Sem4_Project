Database:

docker run --name jipp4-mssql `
  -e "ACCEPT_EULA=Y" `
  -e "SA_PASSWORD=JiPP4@Passw0rd" `
  -p 1433:1433 `
  -v mssql_data:/var/opt/mssql `
  -d mcr.microsoft.com/mssql/server:2022-latest
