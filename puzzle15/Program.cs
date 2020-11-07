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
            
       
            //3 moves
            int[] puzzle3 =
            {
                4, 1, 2, 3,
                8, 5, 6, 7,
                12, 9, 10, 11,
                0, 13, 14, 15
            };
            
            Node root = new Node(puzzle13);
            Bfs bfs = new Bfs();

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