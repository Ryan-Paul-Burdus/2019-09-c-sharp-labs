FROM mcr.microsoft.com/dotnet/core/runtime:2.1-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["lab_38_raw_sql/lab_38_raw_sql.csproj", "lab_38_raw_sql/"]
RUN dotnet restore "lab_38_raw_sql/lab_38_raw_sql.csproj"
COPY . .
WORKDIR "/src/lab_38_raw_sql"
RUN dotnet build "lab_38_raw_sql.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "lab_38_raw_sql.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "lab_38_raw_sql.dll"]