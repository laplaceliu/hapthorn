#!/usr/bin/env bash
# Build and deploy to Docker
if [ -e .env ]
then
    set -o allexport
    source .env
    set +o allexport
fi
echo "Using DOCKER_HOST:"
echo $DOCKER_HOST

cd Hapthorn
dotnet restore && npm install && dotnet publish -c Release -o ../out
cd ..
docker-compose build
