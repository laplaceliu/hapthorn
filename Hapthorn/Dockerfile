FROM microsoft/aspnetcore-build:2.0 AS build-env
MAINTAINER Eric Hoff <eric@willcodeforcoffee.ca>

RUN apt-get update -qq \
 && apt-get install -y apt-transport-https ca-certificates
RUN curl -sL https://deb.nodesource.com/setup_8.x | /bin/bash -
RUN apt-get update -qq && apt-get install -y build-essential nodejs

WORKDIR /src

# Copy csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
MAINTAINER Eric Hoff <eric@willcodeforcoffee.ca>
LABEL Name=hapthorn Version=0.0.3

WORKDIR /app
COPY --from=build-env /src/out .
EXPOSE 5000
ENTRYPOINT ["dotnet", "Hapthorn.dll"]