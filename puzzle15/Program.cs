﻿using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace puzzle15
{
    class Program
    {
        static void Main(string[] args)
        {

            void display(List<Node> solution)
            {
                Console.WriteLine(solution.Count - 1);
                if (solution.Count > 0)
                {
                    String moves = "";
                    for(int i = 0; i < solution.Count - 1; i++)
                    {
              
                        if (solution[i]._zeroIndex - solution[i + 1]._zeroIndex == -1)
                        {
                            moves += "R";
                            Console.WriteLine("R");
                        }
                        else if (solution[i]._zeroIndex - solution[i + 1]._zeroIndex == 1)
                        {
                            moves += "L";
                            Console.WriteLine("L");
                        }
                        else if(solution[i]._zeroIndex - solution[i + 1]._zeroIndex == -4)
                        {
                            moves += "D";
                            Console.WriteLine("D");
                        }
                        else
                        { 
                            moves += "U";
                            Console.WriteLine("U");
                        }
                        solution[i].PrintPuzzle();
                    }
                    //Console.WriteLine(moves);
                }
                else
                {
                    Console.WriteLine("No solution found");
                }
            }
            

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

            if (args.Length>0)
            {
                Node root = new Node(puzzle3);
                Node rootStar = new Node(puzzle22, 0);
                List<Node> solution = new List<Node>();
                switch (args[0])
                {
                    case "--bfs":
                        if (args.Length > 1)
                        { 
                            Bfs bfs = new Bfs(args[1]);
                            solution = bfs.BreathFirstSearch(root); 
                        }
                        
                        break;
                    case "--dfs":
                        if (args.Length > 1)
                        {
                            Dfs dfs = new Dfs(args[1]);
                            solution = dfs.DepthFirstSearch(root);
                        }
                        
                        break;
                    case "--ids":
                        if (args.Length > 1)
                        {
                            Ids ids = new Ids(args[1]);
                            solution = ids.IterativeDeepingSearch(root, 11);
                        }
                        break;
                    case "--astar":
                        Astar astar = new Astar();
                        solution = astar.AStar(rootStar);
                        break;
                    default:
                        Console.Write("No such option!");
                        break;
                }
                display(solution);
                
                
            }
        }
    }
}