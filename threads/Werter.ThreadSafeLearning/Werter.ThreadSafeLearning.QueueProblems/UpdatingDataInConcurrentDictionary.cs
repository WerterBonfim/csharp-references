using System;
using System.Collections.Concurrent;

namespace Werter.ThreadSafeLearning.QueueProblems
{
    public sealed class UpdatingDataInConcurrentDictionary : ExamplesBase
    {
        public override void Demo()
        {
            var robotGems = new ConcurrentDictionary<string, int>();

            robotGems.TryAdd(key: "Robot1", value: 10);
            robotGems.TryAdd(key: "Robot2", value: 20);
            robotGems.TryAdd(key: "Robot3", value: 30);
            robotGems.TryAdd(key: "Robot4", value: 40);


            if (robotGems.TryAdd("robot4", 44))
            {
                Console.WriteLine("Robot4 add to the diciontary.");
            }
            else
            {
                // returns false: Does not alter dictionary when key exists in dictionary (without throwing exception)
                Console.WriteLine("Cannot add, Robot4 already  in the dictionary.");
            }

            WriteHeaderToConsole("Starting Values");
            foreach (var keyPair in robotGems)
            {
                Console.WriteLine($"{keyPair.Key}:, GemstoneCount: {keyPair.Value}");
            }


            // one way to update an item
            int foundCount = SearchForGems();
            Console.WriteLine($"GemStone found: {foundCount}");

            int currentGemCount = robotGems["Robot3"];

            // while current thread is running, the currentGemCount == 30
            // what happens if another thread is scheduled between these 2 line
            // of code?
            // for example it updates "Robot3" gem count to 34
            robotGems["Robot3"] = currentGemCount + foundCount;

            // what we want to happen
            // thread 1, sets dictionary value == 30 + 2
            // thread 2 sets dictionary value == 32 + 4
            // expected result is 36.

            // what really happened, result is 32.  A race condition broke our application!

            Console.ForegroundColor = ConsoleColor.Yellow;

            WriteHeaderToConsole("Updated values");
            Console.WriteLine($"Team count: {robotGems.Count}");

            foreach (var keyPair in robotGems)
            {

                Console.WriteLine($"{keyPair.Key}: , GemstoneCount: {keyPair.Value}");

            }

            Console.ResetColor();

        }

       
        private static int SearchForGems()
        {
            return Ran.Next(1, 5);
        }

        private static Robot IncrementGemCount(string key, Robot robot)
        {
            robot.GemstoneCount += 1;
            return robot;
        }


    }
}
