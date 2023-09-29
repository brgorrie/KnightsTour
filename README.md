
<p align="center">
  <h1 align="center">Knights Tour Problem</h1>
</p>

## Problem Statement

This repository contains a solution to the following problem.

A knight's tour is a sequence of moves by a knight on a chessboard such that all squares are visited once.

Given N, write a function to return the number of knight's tours on an N by N chessboard.

Alright, let's solve this in plain English.

## Understanding the Problem

A knight's tour means the knight needs to visit every square exactly once on an `N x N` chessboard. In chess, a knight moves in an ‘L’ shape, two squares in one direction and one square in the perpendicular direction.

### Approach

1. **Initialize the Board:** 
   - Create a board with `N x N` squares, and initially mark all squares as unvisited.
   
2. **Start the Tour:**
   - Start from any square and mark it as visited.
   - Move the knight to an unvisited square and mark the new square as visited.
   - Continue moving the knight until either all squares are visited or there are no legal moves left.
   - If you visit all squares exactly once, you've found a valid knight's tour!

3. **Backtracking:**
   - If you get stuck and can’t make a legal move, go back to the previous square and try a different move.
   - Continue this process until you’ve tried all possible combinations.

4. **Count the Tours:**
   - Keep a count of valid knight’s tours.
   - Return this count when you’ve tried all possibilities.

### Example
Let’s take a smaller example with a `3 x 3` board to get the idea:

```
1 2 3
4 5 6
7 8 9
```

You pick a starting point, say square `1`. From `1`, a knight can only go to square `6` or `8`. Let's say you go to square `6`. Continue this process and go back when stuck.

### Let’s try to put this in simpler code-like steps:
- For every square:
   1. Mark the square as visited.
   2. For each possible knight move from that square:
      - If the move leads to an unvisited square, make the move and repeat step 1.
   3. If all squares are visited, increment the count.
   4. Mark the square as unvisited (backtrack).

### Backtracking
The most critical concept here is backtracking. When you're trying to find all possible solutions to a problem, you make a series of choices. If you reach a point where you can't make a next valid choice, you have to go back to the last valid state (undo the last choice) and try a different choice.

### Programming
To translate the above approach to code, you could use a recursive function to try every possible move from each square and use backtracking to undo the move if it doesn’t lead to a solution. 

Here's a simplified Python example based on the above approach for an `N x N` board:

```python
def countKnightsTours(N):
    # Initializing the board to unvisited.
    board = [[-1 for _ in range(N)] for _ in range(N)]
    moves = [(2, 1), (1, 2), (-1, 2), (-2, 1), (-2, -1), (-1, -2), (1, -2), (2, -1)]  # possible moves
    
    def isSafe(x, y):
        # Check if i,j are valid indexes for N*N chessboard and the square is not visited.
        return 0 <= x < N and 0 <= y < N and board[x][y] == -1
    
    def solve(x, y, movei):
        # Base Case
        if movei == N * N:  # If all squares are visited
            return 1
        # Try all next moves from current coordinate x, y
        count = 0
        for i in range(8):  # as a knight can have a max of 8 possible moves
            next_x, next_y = x + moves[i][0], y + moves[i][1]
            if isSafe(next_x, next_y):
                # Make the move
                board[next_x][next_y] = movei
                # Recur with the new position
                count += solve(next_x, next_y, movei + 1)
                # Backtrack
                board[next_x][next_y] = -1
        return count
    
    count = 0
    for i in range(N):
        for j in range(N):
            board[i][j] = 0  # start from each square
            count += solve(i, j, 1)  # start moving
            board[i][j] = -1  # reset the board
    return count
```

This code can be optimized further, but it should help you understand the basic idea of solving the Knight's Tour problem. Keep in mind that this problem has a high time complexity and may take a long time for larger values of `N`.

Here is a simplified C# example based on the approach described above. 

The approach is to start from each square on the board and then perform the knight's tour using Depth First Search (DFS) and backtracking to find all possible tours.

```csharp
using System;

class Program
{
    static int N; // the dimension of the board
    static int[,] board; // to keep track of visited squares
    static (int, int)[] moves = { (2, 1), (1, 2), (-1, 2), (-2, 1), (-2, -1), (-1, -2), (1, -2), (2, -1) }; // possible moves

    static bool IsSafe(int x, int y)
    {
        return x >= 0 && y >= 0 && x < N && y < N && board[x, y] == -1;
    }

    static int Solve(int x, int y, int movei)
    {
        if (movei == N * N) return 1; // all squares are visited
        int count = 0;
        for (int i = 0; i < 8; i++) // try all next moves
        {
            int nextX = x + moves[i].Item1, nextY = y + moves[i].Item2;
            if (IsSafe(nextX, nextY))
            {
                board[nextX, nextY] = movei;
                count += Solve(nextX, nextY, movei + 1);
                board[nextX, nextY] = -1; // backtrack
            }
        }
        return count;
    }

    static int CountKnightsTours(int n)
    {
        N = n;
        board = new int[N, N];
        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                board[i, j] = -1; // initialize board as unvisited

        int count = 0;
        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
            {
                board[i, j] = 0; // start from each square
                count += Solve(i, j, 1); // start moving
                board[i, j] = -1; // reset the board
            }

        return count;
    }

    static void Main()
    {
        Console.WriteLine(CountKnightsTours(5)); // replace 5 with desired N
    }
}
```

In this example, the `CountKnightsTours` method initializes the board and starts the knight's tour from each square on the board. The `Solve` method performs Depth First Search (DFS) and backtracking to find all possible tours starting from a given square, and the `IsSafe` method checks whether a move is valid or not.

You can call the `CountKnightsTours` method with the desired value of `N` to get the count of all knight's tours on an `N x N` board.

This C# example should also illustrate how the Knight's Tour problem can be solved using backtracking. Keep in mind that this problem has high computational complexity and may take a long time for larger boards.

## Solution
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

