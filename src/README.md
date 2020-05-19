# RHook

This function provides an easy way to publish to RabbitMQ, using HTTP Post requests.

## Usage

```powershell
func start
```

```powershell
$endpoint = "http://localhost:7071/api/RHook/<QueueName>/<RoutingKey>"
$body = "<message>"
Invoke-WebRequest -Uri $endpoint -Method "POST" -Body $body
```
