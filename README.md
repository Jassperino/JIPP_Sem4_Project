Database:

docker load -i mssql_backup.tar

docker run --name jipp4-mssql \
  -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=JiPP4@Passw0rd" \
  -p 1433:1433 -d jipp4-mssql-image
