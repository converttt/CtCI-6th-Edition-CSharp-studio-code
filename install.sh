#!/bin/bash
dotnet new sln
dotnet sln add "CH 01. Arrays and Strings"/"CH 01. Arrays and Strings".csproj
dotnet sln add test-ctci/test-ctci.csproj
dotnet add test-ctci/test-ctci.csproj reference "CH 01. Arrays and Strings"/"CH 01. Arrays and Strings".csproj
dotnet sln add ctci/ctci.csproj
dotnet add ctci/ctci.csproj reference "CH 01. Arrays and Strings"/"CH 01. Arrays and Strings".csproj
dotnet restore