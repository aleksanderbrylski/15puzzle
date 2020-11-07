using System;
using System.Collections.Generic;

namespace puzzle15
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] puzzle =
            {
                4, 0, 1, 3,
                5, 9, 2, 7,
                8, 13, 6, 15,
                12, 14, 11, 10
            };
            
            Node root = new Node(puzzle);
            BFS bfs = new BFS();

            List<Node> solution = bfs.BreathFirstSearch(root);

            if (solution.Count > 0)
            {
                for(int i = 0; i < solution.Count; i++)
                {
                    solution[i].PrintPuzzle();
                }
            }
            else
            {
                Console.WriteLine("No solution found");
            }
        }
    }
}