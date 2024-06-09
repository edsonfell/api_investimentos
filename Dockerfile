FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY app/*.csproj ./
RUN dotnet restore

COPY app/. .

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
COPY --from=build /app/out ./

EXPOSE 80

ENTRYPOINT ["dotnet", "xp_project.dll"]
