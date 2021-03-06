using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Werter.ThreadSafeLearning.QueueProblems
{

    public sealed class UseLockAndMutex : ExamplesBase
    {
        private static Queue<Robot> _robots = new();
        private static object _lock = new object();
        private static Mutex _mutex = new Mutex();
        private static int _idCounter = 0;

        public override void Demo()
        {
            DemoMultiThread();
        }


        private void DemoMultiThread()
        {
            Console.WriteLine("Use Queue with multi thread");


            _robots = new Queue<Robot>();
            

            var task1 = Task.Run(() => SetupTeam1());
            var task2 = Task.Run(() => SetupTeam2());

            Task.WaitAll(task1, task2);

            _mutex.WaitOne();

            Console.WriteLine();


            while (_robots.TryDequeue(out Robot robot))
            {
                Console.ForegroundColor = robot.TeamColor;
                Console.WriteLine(robot.ToString());
            }

            _mutex.ReleaseMutex();

            Console.ResetColor();
            Console.WriteLine("-------------------------------------");

        }


        private void MakeRoobot(string team, ConsoleColor color)
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


        private void SetupTeam1()
        {
            for (int counter = 10; counter <= 14; counter++)
                MakeRoobot("Starchasers", ConsoleColor.DarkCyan);
        }

        private void SetupTeam2()
        {
            for (int counter = 20; counter <= 24; counter++)
                MakeRoobot("Deltron", ConsoleColor.DarkYellow);
        }

       
    }
}
