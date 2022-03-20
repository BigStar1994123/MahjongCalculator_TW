#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TaiwaneseMahjongCalculator/TaiwaneseMahjongCalculator.csproj", "TaiwaneseMahjongCalculator/"]
RUN dotnet restore "TaiwaneseMahjongCalculator/TaiwaneseMahjongCalculator.csproj"
COPY . .
WORKDIR "/src/TaiwaneseMahjongCalculator"
RUN dotnet build "TaiwaneseMahjongCalculator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaiwaneseMahjongCalculator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaiwaneseMahjongCalculator.dll"]