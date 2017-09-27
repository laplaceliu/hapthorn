#!/usr/bin/env bash
# Build and deploy to Docker
if [ -e .env ]
then
    set -o allexport
    source .env
    set +o allexport
fi
echo "Using DOCKER_HOST:"  $DOCKER_HOST
echo "DOCKER_API_VERSION:" $DOCKER_API_VERSION
docker-compose up