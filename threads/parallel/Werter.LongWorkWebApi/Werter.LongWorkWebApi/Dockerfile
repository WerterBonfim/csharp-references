FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Werter.LongWorkWebApi/Werter.LongWorkWebApi.csproj", "Werter.LongWorkWebApi/"]
RUN dotnet restore "Werter.LongWorkWebApi/Werter.LongWorkWebApi.csproj"
COPY . .
WORKDIR "/src/Werter.LongWorkWebApi"
RUN dotnet build "Werter.LongWorkWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Werter.LongWorkWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Werter.LongWorkWebApi.dll"]
