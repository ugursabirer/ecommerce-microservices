# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["user-service.csproj", "./"]
RUN dotnet restore "user-service.csproj"

# Copy everything else and build
COPY . .
RUN dotnet build "user-service.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "user-service.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Expose port
EXPOSE 5048

ENTRYPOINT ["dotnet", "user-service.dll"]