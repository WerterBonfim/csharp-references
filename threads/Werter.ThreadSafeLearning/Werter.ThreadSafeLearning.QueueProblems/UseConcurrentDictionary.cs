using System;
using System.Collections.Concurrent;

namespace Werter.ThreadSafeLearning.QueueProblems
{
    public class UseConcurrentDictionary : ExamplesBase
    {       

        public override void Demo()
        {

            //var robots = new Dictionary<int, Robot>();
            var robots = new ConcurrentDictionary<int, Robot>();

            Robot robot1, robot2, robot3, robot4, currentRobot, tryRobot;

            #region [ CreateRobots ]

            robot1 = new Robot
            {
                Id = 1,
                Name = "Robot 1",
                Team = "Star-chasers",
                TeamColor = ConsoleColor.DarkYellow,
                GemstoneCount = 10
            };

            robot2 = new Robot
            {
                Id = 2,
                Name = "Robot 2",
                Team = "Star-chasers",
                TeamColor = ConsoleColor.DarkYellow,
                GemstoneCount = 10
            };

            robot3 = new Robot
            {
                Id = 3,
                Name = "Robot 3",
                Team = "Deltron",
                TeamColor = ConsoleColor.Cyan,
                GemstoneCount = 10
            };

            robot4 = new Robot
            {
                Id = 4,
                Name = "Robot 4",
                Team = "Deltron",
                TeamColor = ConsoleColor.Cyan,
                GemstoneCount = 10
            };

            #endregion


            robots.TryAdd(robot1.Id, robot1);
            robots.TryAdd(robot2.Id, robot2);
            robots.TryAdd(robot3.Id, robot3);
            robots.TryAdd(robot4.Id, robot4);


            if (!robots.TryAdd(robot4.Id, robot4))
                Console.WriteLine("Cannot add, robot already in the dictionary");

            ListAllRobotsInDictionary(robots);

            //robots.Remove(1);
            if (robots.TryRemove(1, out robot1)) ;
            Console.WriteLine("Remove robot 1");

            if (!robots.TryRemove(1, out _))
                Console.WriteLine("robot 1 not exists");

            currentRobot = robots[3];
            currentRobot.GemstoneCount += 1;
            robots[3] = currentRobot;

            WriteHeaderToConsole("Use .TryGetValue");
            Console.WriteLine($"Team count: {robots.Count}");

            foreach (var keyPair in robots)
            {
                Console.ForegroundColor = keyPair.Value.TeamColor;
                Console.WriteLine($"{keyPair.Key}: Team: {keyPair.Value.Name}, " +
                    $"{keyPair.Value.Team}, GeamstoneCount: {keyPair.Value.GemstoneCount}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Use .TryGetValue");

            robots.TryGetValue(3, out tryRobot);
            Console.WriteLine(tryRobot.ToString());
            Console.ResetColor();


            currentRobot = robots[3];

            var newRobot = CreateSameRobot();

            currentRobot = robots.GetOrAdd(newRobot.Id, newRobot); // add
            currentRobot = robots.GetOrAdd(newRobot.Id, newRobot); // gets

            ListAllRobotsInDictionary(robots);


        }

        private void ListAllRobotsInDictionary(ConcurrentDictionary<int, Robot> robots)
        {
            WriteHeaderToConsole("List all items in dictionary");
            Console.WriteLine($"Team count: {robots.Count}");

            foreach (var keyPair in robots)
            {
                Console.ForegroundColor = keyPair.Value.TeamColor;
                Console.WriteLine($"{keyPair.Key}: Team: {keyPair.Value.Name}, " +
                    $"{keyPair.Value.Team}, GeamstoneCount: {keyPair.Value.GemstoneCount}");
            }
        }

       

        private Robot CreateSameRobot()
        {


            var robot = new Robot()
            {
                Id = 5,
                Name = $"Robot 5",
                Team = "Star-chasers",
                TeamColor = ConsoleColor.DarkYellow,
                GemstoneCount = 10,
            };
            return robot;
        }
    }
}
