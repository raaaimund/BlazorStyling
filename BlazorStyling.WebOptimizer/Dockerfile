FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["BlazorStyling.WebOptimizer/BlazorStyling.WebOptimizer.csproj", "BlazorStyling.WebOptimizer/"]
RUN dotnet restore "BlazorStyling.WebOptimizer/BlazorStyling.WebOptimizer.csproj"
COPY . .
WORKDIR "/src/BlazorStyling.WebOptimizer"
RUN dotnet build "BlazorStyling.WebOptimizer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorStyling.WebOptimizer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorStyling.WebOptimizer.dll"]