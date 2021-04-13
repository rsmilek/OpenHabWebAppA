# OpenHabWebAppA

## Production Build
### cd OpenHabWebAppA\OpenHabWebAppA
### dotnet publish
### dotnet publish -c Release -r win10-x64 --self-contained true
### dotnet publish -c Release -r win10-x64 --self-contained true /p:PublishTrimmed=true
https://docs.microsoft.com/en-us/dotnet/core/deploying/deploy-with-cli
https://docs.microsoft.com/en-us/dotnet/core/deploying/
https://docs.microsoft.com/en-us/dotnet/core/deploying/trim-self-contained


## Launch
### cd OpenHabWebAppA\OpenHabWebAppA\bin\Debug\netcoreapp3.1\publish
### OpenHabWebAppA.exe
