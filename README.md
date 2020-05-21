# Demos.RabbitMQ

A simple example on how different agents can communicate using [RabbitMQ](https://www.rabbitmq.com/) and [Docker](https://www.docker.com/).

## Setup

1. Clone this repository
1. Run the docker-compose file to start RabbitMQ

```powershell
docker-compose  up -d --build
```

Run the apps:

```powershell
dotnet run "app\Demos.RabbitMQ.PublisherApp"
```

```powershell
dotnet run "app\Demos.RabbitMQ.ConsumerApp"
```

RabbitMQ has a [management GUI](http://localhost:15672/#/)
