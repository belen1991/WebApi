# WebApi
    This is a apirest project with:
    * netcore 5.0
    * sqlserver 2019
    * paretns repository design
    * cleancode
    * swagger to api documentation

#Project Structure
* WebApi
    * Patterns
       * DataBase (Content a docker-file to build sqlserver instance)
       * Entities
       * WebApi (Content a docker-file to build and run api)
       * data_access
       * shared
       * use-cases
       * docker-compose.yml (for build and run all images)
       
# Requeriments
    * install docker deskopt

    * install docker compose
    
# For build docker images
* you need run in console:

  * docker-compose build
  
  * docker-compose run

    * The API RUN in: http://0.0.0.0:9090/api or  http://localhost:9090/api
    * The API DOCS in: http://0.0.0.0:9090/swagger/index.html or  http://localhost:9090/swagger/index.html



# For build and run WebApi Project without docker, dotnet command (---for the DB you need run docker)

* you need run in console:

  * your_local_route\WebApi\Patterns>dotnet build
  * your_local_route\WebApi\Patterns\WebApi>dotnet watch run WebApi.csproj
    
    * The API RUN in: https://localhost:5001/api
    * The API DOCS in: https://localhost:5001/swagger/index.html
   
   
   
  


