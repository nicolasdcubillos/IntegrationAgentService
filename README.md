# IntegrationAgentService
IntegrationAgentService WindowsService (.NET).

## Publish the service

dotnet publish -c Release -r win-x64 --self-contained true -o ./publish

## Install the service (only Windows OS supported)

sc create IntegrationAgentService binPath= "C:\Path\To\publish\IntegrationAgentService.exe"

sc start IntegrationAgentService

sc stop IntegrationAgentService

sc delete IntegrationAgentService