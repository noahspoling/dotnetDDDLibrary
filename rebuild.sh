#!/bin/bash

# Read the dotnetEntities.txt file and perform rebuilding for each project directory listed
while read -r dir; do
    echo "Rebuilding $dir..."
    cd "$dir"
    dotnet clean
    dotnet build
    cd ..
done < dotnetEntities.txt