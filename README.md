# netcore-webapi

[![N|Solid](https://res.cloudinary.com/drqk6qzo7/image/upload/v1560322165/CU34_deploy_aws_with_docker-compose_wlohut.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

project architecture orient of the domain. developed in netcore with dapper, sql server and tdd using docker-compose

[trello](https://trello.com/b/1iv1901p/netcore-webapi) Trello

And of course netcore-webapi itself is open source with a [public repository][afn]
 on GitHub.
 
## Usage

netcore-webapi requires 

[Docker](https://hub.docker.com/editions/community/docker-ce-desktop-windows)
[Git](https://git-scm.com/downloads)

to run.

Install the dependencies and devDependencies previous
start the server.

## download
```sh
git clone https://github.com/afnarqui/netcore-webapi.git
cd netcore-webapi
docker-compose up --build
```

## create image sql server in docker
```docker
docker-compose up --build
```

## create data base travels
```sql
exec create database.sql
```

## run aplication
```sh
http://localhost:8081/
```

## exec contenedor in aws
```sh
docker run --rm -d -p 80:80/tcp afnarqui/netcore:v1
```

## run aplication in production
```sh
http://3.19.120.22/
```


[afn]: <https://github.com/afnarqui/netcore-webapi>