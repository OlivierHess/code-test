FROM mcr.microsoft.com/dotnet/sdk:5.0 AS publish
WORKDIR /work
COPY Src/. ./
RUN dotnet build "Api/Api.csproj" -c Release
RUN dotnet publish "Api/Api.csproj" -c Release -o /app --no-build

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /work
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CodeTest.Api.dll"]