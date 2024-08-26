# Utiliza la imagen oficial de .NET SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
EXPOSE 5024

# Copia solo los archivos del proyecto principal y restaura las dependencias
COPY ["BancoCodigo.csproj", "./"]
RUN dotnet restore

# Copia todos los archivos del proyecto principal y publica la aplicación
COPY . .
WORKDIR /app
RUN dotnet publish "BancoCodigo.csproj" -c Release -o /app/out

# Utiliza la imagen de runtime de .NET para la imagen final
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS final
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "BancoCodigo.dll"]
