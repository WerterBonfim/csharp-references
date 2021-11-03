using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Werter.ThreadSafeLearning.QueueProblems
{

    public class UseLockAndMutex
    {
        private static Queue<Robot> _robots = new();
        private static object _lock = new object();
        private static Mutex _mutex = new Mutex();
        private static int _idCounter = 0;


        public static void Execute()
        {

            try
            {

                DemoMultiThread();

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Exception:{ex.Message}");
                Console.ResetColor();
            }


            Console.ReadKey();
        }





        private static void DemoMultiThread()
        {
            Console.WriteLine("Use Queue with multi thread");


            _robots = new Queue<Robot>();
            

            var task1 = Task.Run(() => SetupTeam1());
            var task2 = Task.Run(() => SetupTeam2());

            Task.WaitAll(task1, task2);

            _mutex.WaitOne();

            Console.WriteLine();


            Robot robot;
            while (_robots.TryDequeue(out robot))
            {
                
                Console.ForegroundColor = robot.TeamColor;
                Console.WriteLine(robot.ToString());
            }

            _mutex.ReleaseMutex();

            Console.ResetColor();
            Console.WriteLine("-------------------------------------");

        }


        private static void MakeRoobot(string team, ConsoleColor color)
        {
            lock (_lock)
            {
                Thread.Sleep(20);
                _idCounter += 1;
                var robot = new Robot
                {
                    Id = _idCounter,
                    Name = $"Robot{_idCounter}",
                    Team = team,
                    TeamColor = color
                };
                _robots.Enqueue(robot);
                Console.WriteLine($"Enqueue, Thread: {Thread.CurrentThread.ManagedThreadId}, Queue.Count: {_robots.Count:D2} Name: {robot.Name}");

            }
        }


        private static void SetupTeam1()
        {
            for (int counter = 10; counter <= 14; counter++)
                MakeRoobot("Starchasers", ConsoleColor.DarkCyan);
        }

        private static void SetupTeam2()
        {
            for (int counter = 20; counter <= 24; counter++)
                MakeRoobot("Deltron", ConsoleColor.DarkYellow);
        }
    }
}
