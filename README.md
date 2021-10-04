# EcommerceNetCoreMicroservice

## Mongo

Running a Mongo docker container:

```bash
  docker run -d -p 27018:27017 --name ecommerce-mongo mongo
```

Manage Mongo docker container:

```bash
  docker ps

  docker exec -it ecommerce-mongo bash

  # OR
  docker exec -it ecommerce-mongo /bin/bash
```

## Microsoft SQL

Running a Microsoft SQL docker container:

```bash
  docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=SwN12345678" -p 1433:1433 -d --name ecommerce-microsoftSQL mcr.microsoft.com/mssql/server
```

Manage Mongo docker container:

```bash
  docker ps

  docker exec -it ecommerce-mongo bash

  # OR
  docker exec -it ecommerce-mongo /bin/bash
```

## Redis

Running a Redis docker container:

```bash
  docker run -d -p 6380:6379 --name ecommerce-redis redis
```

Manage Redis docker container:

```bash
  docker ps

  docker exec -it ecommerce-redis bash

  # OR
  docker exec -it ecommerce-redis /bin/bash

  # Check redis connection
  ping

  # Setting a value
  set key value
  set name philz

  # Getting a value
  get key # "value"
  get name # "philz"

```

## RabbitMQ

Running a Redis docker container:

```bash
  docker run -d -p 15672:15672 -p 5672:5672 --hostname my-rabbitmq  --name ecommerce-rabbitmq rabbitmq:3-management
```

username: guest
password: guest

## Docker

Run compose:

```bash
  docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```

## Migrations

Search Package Manager Console

```bash
  add-migration InitialMigration

  update-database
```
