# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY WebApplication2/WebApplication2.csproj WebApplication2/
RUN dotnet restore WebApplication2/WebApplication2.csproj

# Copy remaining source code files
COPY . .
WORKDIR /src/WebApplication2
RUN dotnet publish -c Release -o /app/publish

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expose port (Render/Railway bind to PORT env, ASP.NET Core 8/9 default to 8080)
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "WebApplication2.dll"]
