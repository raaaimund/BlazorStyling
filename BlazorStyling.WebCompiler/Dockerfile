FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["BlazorStyling.WebCompiler/BlazorStyling.WebCompiler.csproj", "BlazorStyling.WebCompiler/"]
RUN dotnet restore "BlazorStyling.WebCompiler/BlazorStyling.WebCompiler.csproj"
COPY . .
WORKDIR "/src/BlazorStyling.WebCompiler"
RUN dotnet build "BlazorStyling.WebCompiler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorStyling.WebCompiler.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorStyling.WebCompiler.dll"]