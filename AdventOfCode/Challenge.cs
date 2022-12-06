using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{

   
    public static class Challenge
    {  
        public static int GetResult()
        {
            List<string> inputLines = File.ReadAllLines(Path.Combine(Globals.RootInputPath, "Input.txt")).ToList();
            var input = inputLines.Select(x=>new Tuple<List<int>, List<int>>(
                Enumerable.Range(int.Parse(x.Split(",")[0].Split("-")[0]), int.Parse(x.Split(",")[0].Split("-")[1]) - int.Parse(x.Split(",")[0].Split("-")[0]) + 1).ToList(),
                Enumerable.Range(int.Parse(x.Split(",")[1].Split("-")[0]), int.Parse(x.Split(",")[1].Split("-")[1]) - int.Parse(x.Split(",")[1].Split("-")[0]) + 1).ToList()
            )).Where(x=>x.Item1.Any(x1 => x.Item2.Contains(x1)) || x.Item2.Any(x1 => x.Item1.Contains(x1))).ToList();

            return input.Count;
        }
    }
}
