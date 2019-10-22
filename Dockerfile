FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /SurveyShrike-API/Publish
ENTRYPOINT ["dotnet", "SurveyShrike-API.dll"]
