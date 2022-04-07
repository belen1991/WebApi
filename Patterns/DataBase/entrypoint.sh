#/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P abc12345.. -d master -i database.sql
# Run Microsoft SQl Server and initialization script (at the same time)
/DataBase/start.sh & /opt/mssql/bin/sqlservr