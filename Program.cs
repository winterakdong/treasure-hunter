using System;

namespace TreasureHunter
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.BackgroundColor = ConsoleColor.DarkBlue;
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Clear();
      App app = new App();
      app.Setup();
      app.Run();
    }
  }
}
