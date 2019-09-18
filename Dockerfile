FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["MohammadrezaTarkhanCRUDTest.csproj", ""]
RUN dotnet restore "./MohammadrezaTarkhanCRUDTest.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MohammadrezaTarkhanCRUDTest.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MohammadrezaTarkhanCRUDTest.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MohammadrezaTarkhanCRUDTest.dll"]
