#!/bin/bash

# Read the dotnetEntities.txt file and perform cleaning for each project directory listed
while read -r dir; do
    echo "Cleaning $dir..."
    cd "$dir"
    dotnet clean
    cd ..
done < dotnetEntities.txt