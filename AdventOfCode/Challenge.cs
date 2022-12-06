using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Challenge
    {  
        private static int GetPriority(string sack1, string sack2, string sack3)
        {
            var sack1Lookup = sack1.ToList();
            var sack2Lookup = sack2.ToList();
            var sack3Lookup = sack3.ToList();

            var key = sack1Lookup.FirstOrDefault(x => sack2Lookup.Contains(x) && sack3Lookup.Contains(x)).ToString();

            if(key.ToUpper() == key)
            { // upper
                return char.Parse(key) - 38;
            }
            else
            {
                return char.Parse(key) - 96;
            }
        }

        public static int GetResult()
        {
            List<string> inputLines = File.ReadAllLines(Path.Combine(Globals.RootInputPath, "Input.txt")).ToList();
            var input = inputLines.ToList();

            List<int> priorities = new List<int>();
            for (int i = 0; i < input.Count; i+=3)
            {
                priorities.Add(GetPriority(input[i], input[i + 1], input[i + 2]));
            }


            return priorities.Sum();
        }
    }
}
