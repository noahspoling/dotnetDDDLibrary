#!/bin/bash

echo "Please enter the project name:"
read projectname

echo "Do you want to create a new solution (yes/no)?"
read createNewSolution

if [ "$createNewSolution" == "yes" ]; then # if using new solution
    dotnet new sln -n $projectname # Create the solution
    solutionPath="$projectname.sln" # Creates path to solution
else
    echo "Please enter the existing solution path:"
    read solutionPath # prompts for new solution
fi

dotnet new webapi -n $projectname.API # Create the API project
dotnet sln $projectname.sln add $projectname.API/$projectname.API.csproj # adds project to solution
echo "$projectname.API" >> dotnetEntries.txt # adds project to projects text file list

dotnet new classlib -n $projectname.Domain # Create the Domain project
dotnet sln $projectname.sln add $projectname.Domain/$projectname.Domain.csproj # adds project to solution
echo "$projectname.Domain" >> dotnetEntries.txt # adds project to projects text file list

dotnet new classlib -n $projectname.Application # Create the Application project
dotnet sln $projectname.sln add $projectname.Application/$projectname.Application.csproj # adds project to solution
echo "$projectname.Application" >> dotnetEntries.txt # adds project to projects text file list

dotnet new classlib -n $projectname.Infrastructure # Create the Infrastructure project
dotnet sln $projectname.sln add $projectname.Infrastructure/$projectname.Infrastructure.csproj # adds project to solution
echo "$projectname.Infrastructure" >> dotnetEntries.txt # adds project to projects text file list

