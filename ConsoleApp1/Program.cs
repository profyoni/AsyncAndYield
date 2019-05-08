using System;
using System.Data;
using System.Drawing;
using System.Threading;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BoardModel boardModel = new BoardModel();
            boardModel.BoardChanges += CallBackSubscriber;

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            boardModel.Dispose();


            Console.WriteLine("Terminating the application...");

        }


        private static void CallBackSubscriber(Point p, BoardModel.State state)
        {
            Console.WriteLine(p + state.ToString());
        }
    }
}
