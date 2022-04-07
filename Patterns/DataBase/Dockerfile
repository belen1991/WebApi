FROM mcr.microsoft.com/mssql/server:2019-latest
USER root 
RUN mkdir /DataBase
WORKDIR /DataBase

COPY ./DataBase/database.sql .
COPY ./DataBase/start.sh .
COPY ./DataBase/entrypoint.sh .

CMD /bin/bash ./entrypoint.sh
