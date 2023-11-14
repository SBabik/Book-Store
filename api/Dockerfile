#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
# WORKDIR /app
# EXPOSE 80
# EXPOSE 443

# FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
# WORKDIR /src
# COPY ["book_store.csproj", "api/"]
# RUN dotnet restore "api/book_store.csproj"
# COPY . .
# WORKDIR "/src/api"
# RUN dotnet build "api/book_store.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "book_store.csproj" -c Release -o /app/publish /p:UseAppHost=false

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "book_store.dll"]

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env 
WORKDIR /App 
COPY . ./ 
RUN dotnet restore 
RUN dotnet publish -c Release -o out  
FROM mcr.microsoft.com/dotnet/aspnet:7.0 
WORKDIR /App 
COPY --from=build-env /App/out .  
EXPOSE 80 
EXPOSE 443  
ENTRYPOINT ["dotnet", "book_store.dll"] 