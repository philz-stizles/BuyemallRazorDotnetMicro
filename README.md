# EcommerceNetCoreMicroservice

## Mongo

Running a Mongo docker container:

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

## Docker

Run compose:

```bash
  docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```
