FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Afnarqui.Prueba.Services.WebApi/Afnarqui.Prueba.Services.WebApi.csproj", "Afnarqui.Prueba.Services.WebApi/"]
COPY ["Afnarqui.Prueba.Aplication.DTO/Afnarqui.Prueba.Aplication.DTO.csproj", "Afnarqui.Prueba.Aplication.DTO/"]
COPY ["Afnarqui.Prueba.Aplication.Interface/Afnarqui.Prueba.Aplication.Interface.csproj", "Afnarqui.Prueba.Aplication.Interface/"]
COPY ["Afnarqui.Prueba.Transversal.Common/Afnarqui.Prueba.Transversal.Common.csproj", "Afnarqui.Prueba.Transversal.Common/"]
COPY ["Afnarqui.Prueba.Aplication.Logic/Afnarqui.Prueba.Aplication.Logic.csproj", "Afnarqui.Prueba.Aplication.Logic/"]
RUN dotnet restore "Afnarqui.Prueba.Services.WebApi/Afnarqui.Prueba.Services.WebApi.csproj"
COPY . .
WORKDIR "/src/Afnarqui.Prueba.Services.WebApi"
RUN dotnet build "Afnarqui.Prueba.Services.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Afnarqui.Prueba.Services.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Afnarqui.Prueba.Services.WebApi.dll"]
