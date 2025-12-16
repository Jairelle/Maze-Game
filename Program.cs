using System;
using Figgle.Fonts; //For Figgle ASCII Art Letters 

// The entry point class, responsible for initialization and running the game loop.
class Program
{
    static void Main(string[] args)
    {
        // Set console to maximum size
        Console.WindowWidth = Console.LargestWindowWidth;
        Console.WindowHeight = Console.LargestWindowHeight;


        // Difficulty selector and setup
        Console.WriteLine(FiggleFonts.Standard.Render("       Welcome to Maze Game!"));
        Console.WriteLine(FiggleFonts.Standard.Render("Choose difficulty:"));
        Console.WriteLine(FiggleFonts.Standard.Render("(E)asy"));
        Console.WriteLine(FiggleFonts.Standard.Render("(M)edium"));
        Console.WriteLine(FiggleFonts.Standard.Render("(H)ard"));

        ConsoleKey choice = Console.ReadKey(true).Key;

        int width = 91, height = 21; // Default to Hard
        if (choice == ConsoleKey.E) { width = 21; height = 11; }  //For Easy Mode
        else if (choice == ConsoleKey.M) { width = 31; height = 15; }  //For Medium Mode

        // Initialize and run the game
        MazeGame game = new MazeGame(width, height);
        game.Run();
    }
}