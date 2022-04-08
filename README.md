# WebApi
ApiRest with netcore
sqlserver 2019
paretns repository
cleancode

#Project Structure
WebApi
    ---Patterns
       --- DataBase (Content a docker-file to build sqlserver instance)
       --- Entities
       --- WebApi (Content a docker-file to build and run api)
       --- data_access
       --- shared
       --- use-cases
       docker-compose.yml (for build and run all images)
       

# For build docker images
you need run in console:

  docker-compose build
  then
  docker-compose run
  


