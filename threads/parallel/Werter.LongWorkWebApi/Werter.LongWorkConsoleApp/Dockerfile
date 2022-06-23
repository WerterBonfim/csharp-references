FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Werter.LongWorkConsoleApp/Werter.LongWorkConsoleApp.csproj", "Werter.LongWorkConsoleApp/"]
RUN dotnet restore "Werter.LongWorkConsoleApp/Werter.LongWorkConsoleApp.csproj"
COPY . .
WORKDIR "/src/Werter.LongWorkConsoleApp"
RUN dotnet build "Werter.LongWorkConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Werter.LongWorkConsoleApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Werter.LongWorkConsoleApp.dll"]
