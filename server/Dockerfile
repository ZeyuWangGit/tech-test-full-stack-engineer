# Dockerfile for backend service
# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /src

# Copy and restore project files
COPY src/Hipages.Tradies.Api/*.csproj Hipages.Tradies.Api/
COPY src/Hipages.Tradies.Application/*.csproj Hipages.Tradies.Application/
COPY src/Hipages.Tradies.Domain/*.csproj Hipages.Tradies.Domain/
COPY src/Hipages.Tradies.Infrastructure/*.csproj Hipages.Tradies.Infrastructure/
COPY src/Hipages.Tradies.Persistence/*.csproj Hipages.Tradies.Persistence/
COPY test/Hipages.Tradies.Api.IntegrationTests/*.csproj Hipages.Tradies.Api.IntegrationTests/
COPY test/Hipages.Tradies.Application.UnitTests/*.csproj Hipages.Tradies.Application.UnitTests/
RUN dotnet restore "Hipages.Tradies.Api/Hipages.Tradies.Api.csproj"

# Copy the rest of the source code and build
COPY src/ ./
RUN dotnet publish -c Release -o /publish Hipages.Tradies.Api/Hipages.Tradies.Api.csproj

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build-env /publish .

# Start the application
ENTRYPOINT ["dotnet", "Hipages.Tradies.Api.dll"]