
<p align="center">
  <h1 align="center">Knights Tour Problem</h1>
</p>

## Problem Statement

This repository contains a solution to the following problem.

A knight's tour is a sequence of moves by a knight on a chessboard such that all squares are visited once.

Given N, write a function to return the number of knight's tours on an N by N chessboard.

The solution is written in C# and can be executed from the command line. 


To run this solution check it out locally then do the following 

```
dotnet restore
dotnet build
dotnet test 
```
Then to run it you can exexcute the program directly without parameters to see what parameters to use.

```
PS C:\git\KnightsTour> .\src\KnightsTour\bin\Debug\net7.0\KnightsTour.exe
KnightsTour 1.0.0
Copyright (C) 2023 KnightsTour

ERROR(S):
  Required option 'n, boardSize' is missing.
  Required option 'u, unique' is missing.
  Required option 'w, useWarnsdorff' is missing.

  -n, --boardSize        Required. Size of the chess board.

  -u, --unique           Required. Consider unique solutions only.

  -w, --useWarnsdorff    Required. Use Warnsdorff's algorithm.

  --help                 Display this help screen.

  --version              Display version information.

PS C:\git\KnightsTour>
```

Or you can specify parameters to see the output

