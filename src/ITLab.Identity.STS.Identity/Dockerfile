FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/ITLab.Identity.STS.Identity/ITLab.Identity.STS.Identity.csproj", "src/ITLab.Identity.STS.Identity/"]
COPY ["src/ITLab.Identity.Admin.EntityFramework.Shared/ITLab.Identity.Admin.EntityFramework.Shared.csproj", "src/ITLab.Identity.Admin.EntityFramework.Shared/"]
COPY ["src/ITLab.Identity.Admin.EntityFramework.SqlServer/ITLab.Identity.Admin.EntityFramework.SqlServer.csproj", "src/ITLab.Identity.Admin.EntityFramework.SqlServer/"]
COPY ["src/ITLab.Identity.Admin.EntityFramework.PostgreSQL/ITLab.Identity.Admin.EntityFramework.PostgreSQL.csproj", "src/ITLab.Identity.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/ITLab.Identity.Admin.EntityFramework.MySql/ITLab.Identity.Admin.EntityFramework.MySql.csproj", "src/ITLab.Identity.Admin.EntityFramework.MySql/"]
COPY ["nuget.config", "nuget.config"]
RUN dotnet restore "src/ITLab.Identity.STS.Identity/ITLab.Identity.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/ITLab.Identity.STS.Identity"
RUN dotnet build "ITLab.Identity.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ITLab.Identity.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENV ASPNETCORE_URLS=http://*:5501
ENTRYPOINT ["dotnet", "ITLab.Identity.STS.Identity.dll"]