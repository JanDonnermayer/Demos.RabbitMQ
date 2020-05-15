$endpoint = "http://localhost:7071/api/RHook/syncservice/syncservice"
$body = "Hello!"

Invoke-WebRequest -Uri $endpoint -Method "POST" -body $body