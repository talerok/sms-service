FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish SmsService.csproj -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine
WORKDIR /app
COPY --from=build /app .
RUN mkdir -p /data
EXPOSE 5075
ENV ASPNETCORE_URLS=http://+:5075
ENTRYPOINT ["dotnet", "SmsService.dll"]
