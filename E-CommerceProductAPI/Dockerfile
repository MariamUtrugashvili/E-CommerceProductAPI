WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["E-CommerceProductAPI/E-CommerceProductAPI.csproj", "E-CommerceProductAPI/"]
COPY ["E-CommerceProduct.Application/E-CommerceProduct.Application.csproj", "E-CommerceProduct.Application/"]
COPY ["E-CommerceProduct.Domain/E-CommerceProduct.Domain.csproj", "E-CommerceProduct.Domain/"]
COPY ["E-CommerceProduct.Infrastructure/E-CommerceProduct.Infrastructure.csproj", "E-CommerceProduct.Infrastructure/"]
COPY ["E-CommerceProduct.Persistance/E-CommerceProduct.Persistance.csproj", "E-CommerceProduct.Persistance/"]
RUN dotnet restore "./E-CommerceProductAPI/E-CommerceProductAPI.csproj"
COPY . .
WORKDIR "/src/E-CommerceProductAPI"
RUN dotnet build "./E-CommerceProductAPI.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./E-CommerceProductAPI.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "E-CommerceProductAPI.dll"]