# IntegrationAgentService
IntegrationAgentService WindowsService (.NET).

## Publish the service

dotnet publish -c Release -r win-x64 --self-contained true -o ./publish

## Install the service

sc.exe create IntegrationAgentService binPath= "C:\Path\To\publish\IntegrationAgentService.exe"

sc.exe start IntegrationAgentService

sc.exe stop IntegrationAgentService

sc.exe delete IntegrationAgentService

Note: For MacOS, run: dotnet start - it will run the Windows Service as a console app.