using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Werter.ThreadSafeLearning.QueueProblems
{
	public class WrongScenario
	{
		private static Queue<Robot> _robots = new();


		public static void Execute(bool multiThread)
		{

			try
			{
				if (multiThread)
					Demo2MultiThread();
				else
					Demo1SimpleThread();
			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"Exception:{ex.Message}");
				Console.ResetColor();
			}


			Console.ReadKey();
		}



		private static void Demo1SimpleThread()
		{
			Console.WriteLine("Use Queue with single thread");


			_robots = new Queue<Robot>();
			SetupTeam1();
			SetupTeam2();

			Robot robot;

			Console.WriteLine();

			while (_robots.Count > 0)
			{
				robot = _robots.Dequeue();
				Console.ForegroundColor = robot.TeamColor;
				Console.WriteLine(robot.ToString());
			}

			Console.ResetColor();
			Console.WriteLine("---------------------------------------------------");

		}

		private static void Demo2MultiThread()
		{
			Console.WriteLine("Use Queue with multi thread");


			_robots = new Queue<Robot>();

			var task1 = Task.Run(() => SetupTeam1());
			var task2 = Task.Run(() => SetupTeam2());

			Task.WaitAll(task1, task2);

			Robot robot;
            Console.WriteLine();

            while (_robots.Count > 0)
            {
				robot = _robots.Dequeue();
				Console.ForegroundColor = robot.TeamColor;
                Console.WriteLine(robot.ToString());
            }


			Console.ResetColor();
			Console.WriteLine("-------------------------------------");

		}



		private static void SetupTeam1()
		{
			Robot robot;

			for (int counter = 10; counter <= 14; counter++)
			{
				Thread.Sleep(1);
				robot = new Robot
				{
					Id = counter,
					Name = $"Robot{counter}",
					Team = "Starchasers",
					TeamColor = ConsoleColor.DarkCyan
				};

				_robots.Enqueue(robot);
				Console.WriteLine($"Enqueue, Thread: {Thread.CurrentThread.ManagedThreadId}, Queue.Count: {_robots.Count:D2} Name: {robot.Name}");

			}
		}

		private static void SetupTeam2()
		{
			Robot robot;

			for (int counter = 20; counter <= 24; counter++)
			{
				Thread.Sleep(1);
				robot = new Robot
				{
					Id = counter,
					Name = $"Robot{counter}",
					Team = "Deltron",
					TeamColor = ConsoleColor.DarkYellow
				};

				_robots.Enqueue(robot);
				Console.WriteLine($"Enqueue, Thread: {Thread.CurrentThread.ManagedThreadId}, Queue.Count: {_robots.Count:D2} Name: {robot.Name}");

			}
		}
	}
}
