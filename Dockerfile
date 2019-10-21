FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY SurveyShrike-API/*.csproj ./SurveyShrike-API/
RUN dotnet restore

# copy everything else and build app
COPY SurveyShrike-API/. ./SurveyShrike-API/
WORKDIR /app/SurveyShrike-API
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY --from=build /app/SurveyShrike-API/out ./
ENTRYPOINT ["dotnet", "SurveyShrike-API.dll"]