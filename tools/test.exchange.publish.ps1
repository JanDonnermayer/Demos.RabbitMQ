$body = ConvertTo-Json @{
    properties = @{

    }
    routing_key = "syncservice"
    payload = "hello"
    payload_encoding = "string"
}

Write-Output $body

$endpoint = "http://localhost:15672/api/exchanges/%2F/amq.default/publish"
$cred = Get-Credential

Invoke-WebRequest -Uri $endpoint -Method "POST" -Body $body -Credential $cred -AllowUnencryptedAuthentication