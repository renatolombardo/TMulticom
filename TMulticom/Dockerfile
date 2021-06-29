#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
RUN apt update -y \
	&& apt install -y nodejs npm 
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TMulticom/TMulticom.Web.csproj", "TMulticom/"]
COPY ["TMulticom.Domain/TMulticom.Domain.csproj", "TMulticom.Domain/"]
COPY ["TMulticom.Data/TMulticom.Data.csproj", "TMulticom.Data/"]
RUN dotnet restore "TMulticom/TMulticom.Web.csproj"
COPY . .
WORKDIR "/src/TMulticom"
RUN dotnet build "TMulticom.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TMulticom.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TMulticom.Web.dll"]