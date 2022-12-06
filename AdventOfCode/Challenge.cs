using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{

   
    public static class Challenge
    {  
        private static List<List<string>> GetInitial(List<string> lines)
        {
            List<List<string>> list = new List<List<string>>();
            for (int i = 0; i < 9; i++)
            {
                list.Add(new List<string>());
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if(lines[i][j*4 + 1].ToString() != " ")
                    {
                        list[j].Add(lines[i][j * 4 + 1].ToString());
                    }
                }
            }

            return list.Select(x => (x.AsEnumerable()).ToList()).ToList();

        }


        public static string GetResult()
        {
            List<string> inputLines = File.ReadAllLines(Path.Combine(Globals.RootInputPath, "Input.txt")).ToList();
            var state = GetInitial(inputLines);
            var moves = inputLines.Skip(10).Select(x => new Tuple<int, int, int>(int.Parse(x.Split(' ')[1]), int.Parse(x.Split(' ')[3]), int.Parse(x.Split(' ')[5]))).ToList();

            foreach (var move in moves)
            {
                var source = state[move.Item2 - 1].Take(move.Item1).ToList();
                //source.Reverse();
                state[move.Item2 - 1].RemoveRange(0, move.Item1);
                state[move.Item3 - 1].InsertRange(0, source);
            }

            return string.Join("", state.Where(x=>x.Count> 0).Select(x=>x[0]));
        }
    }
}
