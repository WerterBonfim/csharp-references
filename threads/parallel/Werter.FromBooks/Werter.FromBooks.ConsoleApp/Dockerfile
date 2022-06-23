FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Werter.FromBooks.ConsoleApp/Werter.FromBooks.ConsoleApp.csproj", "Werter.FromBooks.ConsoleApp/"]
RUN dotnet restore "Werter.FromBooks.ConsoleApp/Werter.FromBooks.ConsoleApp.csproj"
COPY . .
WORKDIR "/src/Werter.FromBooks.ConsoleApp"
RUN dotnet build "Werter.FromBooks.ConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Werter.FromBooks.ConsoleApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Werter.FromBooks.ConsoleApp.dll"]
