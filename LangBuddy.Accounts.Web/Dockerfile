#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LangBuddy.Accounts.Web/LangBuddy.Accounts.Web.csproj", "LangBuddy.Accounts.Web/"]
COPY ["LangBuddy.Accounts.Database/LangBuddy.Accounts.Database.csproj", "LangBuddy.Accounts.Database/"]
COPY ["LangBuddy.Accounts.Service/LangBuddy.Accounts.Service.csproj", "LangBuddy.Accounts.Service/"]
COPY ["LangBuddy.Accounts.Models/LangBuddy.Accounts.Models.csproj", "LangBuddy.Accounts.Models/"]
RUN dotnet restore "LangBuddy.Accounts.Web/LangBuddy.Accounts.Web.csproj"
COPY . .
WORKDIR "/src/LangBuddy.Accounts.Web"
RUN dotnet build "LangBuddy.Accounts.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LangBuddy.Accounts.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LangBuddy.Accounts.Web.dll"]