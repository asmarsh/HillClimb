using System;
using System.Text;

namespace HillClimb
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            string best = GenerateRandomSolution(random);
            int bestScore = Evaluate(best);

            var epoch = 0;
            var mutations = 0;

            while (true)
            {
                epoch++;

                Console.WriteLine($"Best score so far {bestScore} Solution {best} Epoch {epoch} Mutations {mutations}");

                if (bestScore == 0)
                {
                    break;
                }

                string newSolution = new string(best);
                newSolution = MutateSolution(random, newSolution);

                var score = Evaluate(newSolution);
                if (score < bestScore)
                {
                    best = newSolution;
                    bestScore = score;
                    mutations++;
                }
            }
        }

        private static string GenerateRandomSolution(Random random, int length = 11)
        {
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append(GetRandomChar(random));
            }

            return stringBuilder.ToString();
        }

        private static int Evaluate(string solution)
        {
            var target = "Hello World";

            var diff = 0;

            for (int i = 0; i < solution.Length; i++)
            {
                var s = solution[i];
                var t = target[i];
                diff += Math.Abs((int)s - (int)t);
            }
            return diff;
        }

        private static string MutateSolution(Random random, string solution)
        {
            var index = random.Next(0, solution.Length);

            var mutated = new StringBuilder(solution);
            mutated[index] = GetRandomChar(random);

            return mutated.ToString();
        }

        private static char GetRandomChar(Random random)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890 ";
            
            return chars[random.Next(chars.Length)];
        }
    }
}
