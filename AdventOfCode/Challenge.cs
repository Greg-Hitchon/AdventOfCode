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
            //string input = File.ReadAllText(Path.Combine(Globals.RootInputPath, "Input.txt"));


            var results = new Dictionary<string, int>();
            List<string> currentPaths = new List<string>();

            foreach (var line in inputLines)
            {
                if (line.StartsWith("$ cd ") && !line.Contains("."))
                {
                    string currentPath = string.Join("//", currentPaths) + "//" + $"{line.Split(" ")[2]}";
                    currentPaths.Add(currentPath);
                    results.Add(currentPath, 0);
                }
                else if(line == "$ cd ..")
                {
                    currentPaths.RemoveAt(currentPaths.Count - 1);
                }
                else if(!line.StartsWith("dir") && !line.StartsWith("$"))
                {
                    int size = int.Parse(line.Split(" ")[0]);
                    foreach (var path in currentPaths)
                    {
                        results[path] += size;
                    }
                }
            }

            int used = results["///"];
            int needed = used - 40000000;

            return results.Select(x => x.Value).OrderBy(x => x).FirstOrDefault(x => x >= needed);
        }
    }
}
