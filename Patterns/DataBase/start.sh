# Note: make sure that your password matches what is in the Dockerfile
#/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P abc12345.. -d master -i database.sql


for i in {1..50};
do
    /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P abc12345.. -d master -i database.sql
    if [ $? -eq 0 ]
    then
        echo "database completed"
        break
    else
        echo "not ready yet..."
        sleep 1
    fi
done