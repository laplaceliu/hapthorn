# This is the Dockerfile for producing a Published Docker
FROM microsoft/aspnetcore:2.0
LABEL Name="hapthorn" Version="0.0.4" Author="Eric Hoff <eric@willcodeforcoffee.ca>"

RUN apt-get update -qq \
 && apt-get install -y apt-transport-https ca-certificates gnupg2 \
 && curl -sL https://deb.nodesource.com/setup_8.x | /bin/bash - \
 && apt-get update -qq && apt-get install -y build-essential nodejs

WORKDIR /app
COPY ./out /app
EXPOSE 5000
ENTRYPOINT ["dotnet", "Hapthorn.dll", "web"]
