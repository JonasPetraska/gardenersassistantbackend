#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["Garden.API/Garden.API.csproj", "Garden.API/"]
RUN dotnet restore "Garden.API/Garden.API.csproj"
COPY . .
WORKDIR "/src/Garden.API"
RUN dotnet build "Garden.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Garden.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Garden.API.dll"]