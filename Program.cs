using System;

namespace TreasureHunter
{
    class Program
    {
        static void Main(string[] args)
        {
            App app;
            //NOTE 11 & 12 capture the console colors before changing them so that on 22 & 23 we could reset the colors of the console back to what the user had them before running the application
            var BackgroundColor = Console.BackgroundColor;
            var ForegroundColor = Console.ForegroundColor;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            do
            {
                Console.Clear();
                app = new App();
                app.Setup();
                app.Run();
            } while (app.Playing == false); //FIXME should continue playing only if App.Playing is true
            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = ForegroundColor;
        }
    }
}
