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
            unchecked
            {
                int x = Int32.MaxValue;
                Console.WriteLine(x);

                ++x;
                Console.WriteLine(x);

                Console.ReadKey();
            }
            
        }
        public static void Main2(string[] args)
        {
            BoardModel boardModel = new BoardModel();
            boardModel.BoardChangesEvent += CallBackSubscriber1;
            boardModel.BoardChangesEvent += CallBackSubscriber2;
            boardModel.BoardChangesEvent += CallBackSubscriber3;

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            boardModel.Dispose();


            Console.WriteLine("Terminating the application...");

        }


        private static void CallBackSubscriber1(Point p, BoardModel.State state)
        {
            ExceptionHandle(() =>
            {
                Console.WriteLine("CallBackSubscriber1" + p + state.ToString());
            });
        }
        private static void CallBackSubscriber2(Point p, BoardModel.State state)
        {
            ExceptionHandle(() =>
            {
                Console.WriteLine("CallBackSubscriber2" + p + state.ToString());
                throw new Exception("Bomb");
            });
        }

        private static void ExceptionHandle(Action action)
        {
            try{action();}
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }

        private static void CallBackSubscriber3(Point p, BoardModel.State state)
        {
            Console.WriteLine("CallBackSubscriber3" + p + state.ToString());
        }
    }
}
