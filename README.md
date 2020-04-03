# Demos.RabbitMQ

A simple example on how different agents can communicate using RabbitMQ and Docker.

## Setup

1. Clone this repository
1. Run the docker-compose file to start RabbitMQ

```powershell
docker-compose  up -d --build
```

Run the apps:

```powershell
dotnet run "app\AzureDemos.SignalR.PublisherApp"
```

```powershell
dotnet run "app\AzureDemos.SignalR.ConsumerApp"
```
