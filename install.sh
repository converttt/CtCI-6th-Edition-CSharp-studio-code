#!/bin/bash
dotnet new sln
dotnet sln add "CH 01. Arrays and Strings"/"CH 01. Arrays and Strings".csproj
dotnet sln add test-ctci/test-ctci.csproj
dotnet add test-ctci/test-ctci.csproj reference "CH 01. Arrays and Strings"/"CH 01. Arrays and Strings".csproj
dotnet sln add ctci/ctci.csproj
dotnet add ctci/ctci.csproj reference "CH 01. Arrays and Strings"/"CH 01. Arrays and Strings".csproj
dotnet sln add "CH 02. Linked Lists"/"CH 02. Linked Lists".csproj
dotnet add test-ctci/test-ctci.csproj reference "CH 02. Linked Lists"/"CH 02. Linked Lists".csproj
dotnet sln add lib-ctci/lib-ctci.csproj
dotnet add "CH 02. Linked Lists"/"CH 02. Linked Lists".csproj reference lib-ctci/lib-ctci.csproj
dotnet add test-ctci/test-ctci.csproj reference lib-ctci/lib-ctci.csproj
dotnet sln add "CH 04. Trees and Graphs"/"CH 04. Trees and Graphs".csproj
dotnet add test-ctci/test-ctci.csproj reference "CH 04. Trees and Graphs"/"CH 04. Trees and Graphs".csproj
dotnet add  "CH 04. Trees and Graphs"/"CH 04. Trees and Graphs".csproj reference lib-ctci/lib-ctci.csproj
dotnet sln add Introduction/Introduction.csproj
dotnet add test-ctci/test-ctci.csproj reference Introduction/Introduction.csproj
dotnet sln add "CH 05. Bit Manipulations"/"CH 05. Bit Manipulations".csproj
dotnet add test-ctci/test-ctci.csproj reference "CH 05. Bit Manipulations"/"CH 05. Bit Manipulations".csproj
dotnet sln add "Common Topics"/"Common Topics".csproj
dotnet add test-ctci/test-ctci.csproj reference "Common Topics"/"Common Topics".csproj
dotnet add "Common Topics"/"Common Topics".csproj reference lib-ctci/lib-ctci.csproj
dotnet add ctci/ctci.csproj reference "Common Topics"/"Common Topics".csproj
dotnet restore