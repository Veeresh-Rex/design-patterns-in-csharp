using System;
using System.Collections.Generic;
using TicTacToe.Model;

namespace TicTacToe;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("======================================");
        Console.WriteLine("   WELCOME TO TIC-TAC-TOE DEMO SYSTEM ");
        Console.WriteLine("======================================");
        Console.WriteLine();

        // 1. Initialize Players
        Player player1 = new Player("P1", "Alice", new Symbol('X'));
        Player player2 = new Player("P2", "Bob", new Symbol('O'));

        List<Player> players = new List<Player> { player1, player2 };

        // 2. Get TicTacToe Instance & Create Game
        TicTacToe gameManager = TicTacToe.GetInstance();
        Console.WriteLine("[INFO] Creating a new Tic-Tac-Toe Game (3x3)...");
        gameManager.CreateGame(players, 3);
        Console.WriteLine();

        Console.WriteLine("--- Initial Board ---");
        gameManager.DisplayBoard();
        Console.WriteLine();

        // 3. Simulate Gameplay
        Console.WriteLine("--- Move 1: Alice places X at (0, 0) ---");
        gameManager.MakeMove(0, 0);
        Console.WriteLine();

        Console.WriteLine("--- Move 2: Bob places O at (0, 1) ---");
        gameManager.MakeMove(0, 1);
        Console.WriteLine();

        Console.WriteLine("--- Move 3: Alice places X at (1, 1) ---");
        gameManager.MakeMove(1, 1);
        Console.WriteLine();

        Console.WriteLine("--- Move 4: Attempting invalid move - Bob places O at occupied cell (0, 0) ---");
        gameManager.MakeMove(0, 0);
        Console.WriteLine();

        Console.WriteLine("--- Move 5: Bob places O at (0, 2) ---");
        gameManager.MakeMove(0, 2);
        Console.WriteLine();

        Console.WriteLine("--- Move 6: Alice places X at (2, 2) -> Completes Diagonal Win ---");
        gameManager.MakeMove(2, 2);
        Console.WriteLine();

        Console.WriteLine("--- Move 7: Attempting move after game has ended ---");
        gameManager.MakeMove(1, 0);
        Console.WriteLine();

        Console.WriteLine("======================================");
        Console.WriteLine("        DEMO COMPLETED SUCCESSFULLY    ");
        Console.WriteLine("======================================");
    }
}
