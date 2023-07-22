#!/bin/bash

# Read the dotnetEntities.txt file and perform building for each project directory listed
while read -r dir; do
    echo "Building $dir..."
    cd "$dir"
    dotnet build
    cd ..
done < dotnetEntities.txt
