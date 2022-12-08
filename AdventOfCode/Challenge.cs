using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{

   
    public static class Challenge
    {

        public static List<int> Up(int[,] input, int i, int j)
        {
            List<int> result = new List<int>();
            for (int k = i-1; k >= 0 ; k--)
            {
                result.Add(input[k, j]);
            }
            return result;
        }

        public static List<int> Down(int[,] input, int i, int j)
        {
            List<int> result = new List<int>();
            for (int k = i+1; k < input.GetLength(0); k++)
            {
                result.Add(input[k, j]);
            }
            return result;
        }

        public static List<int> Left(int[,] input, int i, int j)
        {
            List<int> result = new List<int>();
            for (int k = j - 1; k >= 0; k--)
            {
                result.Add(input[i, k]);
            }
            return result;
        }

        public static List<int> Right(int[,] input, int i, int j)
        {
            List<int> result = new List<int>();
            for (int k = j + 1; k < input.GetLength(1); k++)
            {
                result.Add(input[i, k]);
            }
            return result;
        }

        public static int GetScore(List<int> heights, int current)
        {
            if (heights.Count == 0) return 0;
            int temp = heights.TakeWhile(x => x < current).Count();
            return temp + (temp != heights.Count ? 1 : 0);
        }

        public static int GetResult()
        {
            List<string> inputLines = File.ReadAllLines(Path.Combine(Globals.RootInputPath, "Input.txt")).ToList();
            //string input = File.ReadAllText(Path.Combine(Globals.RootInputPath, "Input.txt"));

            int[,] input = new int[inputLines.Count, inputLines[0].Length];
            for (int i = 0; i < inputLines.Count; i++)
            {
                for (int j = 0; j < inputLines[i].AsEnumerable().Count(); j++)
                {
                    input[i, j] = int.Parse(inputLines[i][j].ToString());
                }
            }

            int maxScore = int.MinValue;
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    int currentHeight = input[i, j];
                    int score = GetScore(Left(input, i, j), currentHeight) *
                        GetScore(Right(input, i, j), currentHeight) *
                        GetScore(Up(input, i, j), currentHeight) *
                        GetScore(Down(input, i, j), currentHeight);

                    if (score > maxScore)
                    {
                        maxScore = score;
                    }
                }
            }


            return maxScore;
        }
    }
}
