using System;

namespace TreasureHunter
{
  class Program
  {
    static void Main(string[] args)
    {
      App app;
      do
      {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Clear();
        app = new App();
        app.Setup();
        app.Run();
      } while (app.Playing == false);
    }
  }
}
