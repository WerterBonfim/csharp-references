FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Werter.ListasConcorrentes.ConsoleApp/Werter.ListasConcorrentes.ConsoleApp.csproj", "Werter.ListasConcorrentes.ConsoleApp/"]
RUN dotnet restore "Werter.ListasConcorrentes.ConsoleApp/Werter.ListasConcorrentes.ConsoleApp.csproj"
COPY . .
WORKDIR "/src/Werter.ListasConcorrentes.ConsoleApp"
RUN dotnet build "Werter.ListasConcorrentes.ConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Werter.ListasConcorrentes.ConsoleApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Werter.ListasConcorrentes.ConsoleApp.dll"]
