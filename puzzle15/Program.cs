using System;
using System.Collections.Generic;

namespace puzzle15
{
    class Program
    {
        static void Main(string[] args)
        {

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
            
            //13 moves
            int[] puzzle13 =
            {
                1, 2, 3, 0,
                5, 7, 11, 4,
                10, 6, 12, 8,
                9, 13, 14, 15
            };
            
            //22 moves
            int[] puzzle22 =
            {
                5, 1, 2, 3,
                10, 7, 11, 4,
                9, 0, 12, 8,
                13, 6, 14, 15
            };
            
            //32 moves
            int[] puzzle32 =
            {
                5, 1, 11, 2,
                10, 7, 14, 3,
                9, 12, 4, 0,
                13, 6, 15, 8
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
            
            Node root = new Node(puzzle10);
            Bfs bfs = new Bfs();
            Dfs dfs = new Dfs();
            Ids ids = new Ids();
            Astar astar = new Astar();
            Node rootStar = new Node(puzzle32, 0);

            //List<Node> solution = bfs.BreathFirstSearch(root);
            //List<Node> solution = dfs.DepthFirstSearch(root);
             // List<Node> solution = ids.IterativeDeepingSearch(root, 15);
            List<Node> solution = astar.AStar(rootStar);
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