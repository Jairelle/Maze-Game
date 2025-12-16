using System;
using System.Diagnostics;
using Figgle.Fonts; //For Figgle ASCII Art Letters  

class MazeGame
{
    private readonly Maze _maze;
    private readonly Player _player;
    private readonly Stopwatch _timer = new Stopwatch();

    public MazeGame(int width, int height)
    {
        _maze = new Maze(width, height);
        _player = new Player(_maze);
    }

    public void Run()
    {
        _maze.Draw();

        // Initial player draw
        Console.SetCursorPosition(_player.X, _player.Y);
        Console.Write('P');

        _timer.Start();

        while (true)
        {
            // Update and display the timer
            Console.SetCursorPosition(0, _maze.Height);
            Console.Write($"⏱ Time: {_timer.Elapsed.Minutes:D2}:{_timer.Elapsed.Seconds:D2}    ");

            ConsoleKey key = Console.ReadKey(true).Key;

            _player.TryMove(key);

            if (_player.HasFinished())
            {
                _timer.Stop();
                DisplayVictoryMessage();
                break;
            }
        }
        // Prevents the console from closing immediately after finishing
        Console.ReadKey();
    }

    private void DisplayVictoryMessage()
    {
        Console.SetCursorPosition(0, _maze.Height + 1);
        Console.WriteLine(FiggleFonts.Standard.Render("🎉 You reached the finish!"));
        Console.WriteLine(FiggleFonts.Speed.Render($"⏱ Final Time: {_timer.Elapsed.Minutes:D2}:{_timer.Elapsed.Seconds:D2}"));
    }
}