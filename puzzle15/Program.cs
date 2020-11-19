using System;
using System.Collections.Generic;

namespace puzzle15
{
    class Program
    {
        static void Main(string[] args)
        {
            //13 moves
            int[] puzzle13 =
            {
                4, 1, 0, 3,
                5, 9, 2, 7,
                8, 13, 6, 15,
                12, 14, 11, 10
            };
            
            //9 moves
            int[] puzzle9 =
            {
                5, 1, 3, 4,
                0, 2, 7, 8,
                10, 6, 11, 12,
                9, 13, 14, 15
            };
            
            //10 moves
            int[] puzzle10 =
            {
                1, 2, 3, 4,
                5, 7, 11, 8,
                10, 6, 12, 15,
                9, 13, 14, 0
            };
                
            //8 moves
            int[] puzzle8 =
            {
                1, 2, 3, 4,
                5, 7, 11, 8,
                10, 6, 0, 12,
                9, 13, 14, 15
            };
            
            //6 moves
            int[] puzzle6 =
            {
                1, 2, 3, 4,
                5, 0, 7, 8,
                10, 6, 11, 12,
                9, 13, 14, 15
            };
            
       
            //3 moves
            int[] puzzle3 =
            {
                1, 2, 3, 4,
                5, 6, 7, 8,
                9, 10, 11, 12,
                0, 13, 14, 15
            };
            
            Node root = new Node(puzzle8);
            Bfs bfs = new Bfs();
            Dfs dfs = new Dfs();
            Ids ids = new Ids();

            //List<Node> solution = bfs.BreathFirstSearch(root);
            //List<Node> solution = dfs.DepthFirstSearch(root);
            List<Node> solution = ids.IterativeDeepingSearch(root, 8);

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