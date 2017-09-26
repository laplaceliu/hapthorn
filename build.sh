#!/usr/bin/env bash
# Build and deploy to Docker
cd Hapthorn
dotnet restore
npm install
dotnet publish -c Release -o ../out
cd ..
docker build .