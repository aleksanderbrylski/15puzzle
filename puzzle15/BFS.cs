using System;
using System.Collections.Generic;

namespace puzzle15
{
    public class BFS
    {
        public BFS()
        {
            
        }

        public List<Node> BreathFirstSearch(Node root)
        {
            List<Node> pathToSolution  = new List<Node>();
            List<Node> openList = new List<Node>(); //nodes that were not visited yet
            List<Node> closedList = new List<Node>(); //nodes that were visited
            
            openList.Add((root));
            bool isSolved = false;

            while (openList.Count > 0 && !isSolved)
            {
                //current node is first node from open list
                //it is added to closed list and removed from open list
                Node currentNode = openList[0];
                closedList.Add(currentNode);
                openList.RemoveAt(0);
                
                currentNode.ExpandMove();
                //currentNode.PrintPuzzle();
                
                for (int i = 0; i < currentNode.children.Count; i++)
                {
                    Node currentChild = currentNode.children[i];
                    if (currentChild.IsSolved())
                    {
                        Console.WriteLine("Success ;)");
                        isSolved = true;
                        
                        //trace path to root node
                        PathTrace(pathToSolution, currentChild);
                    }
                    
                    //Checks if openList or closed list contains currentChild
                    if (!Contains(openList, currentChild) && !Contains(closedList, currentChild))
                    {
                        openList.Add(currentChild);
                    }
                }
                
            }

            return pathToSolution;
        }

        public static bool Contains(List<Node> list, Node n)
        {
            bool contains = false;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IsIdentical(n.puzzle))
                {
                    contains = true;
                }
            }

            return contains;
        }

        public void PathTrace(List<Node> path, Node n)
        {
            Console.WriteLine("Path...");
            Node current = n;
            path.Add(current);

            while (current.parent != null)
            {
                current = current.parent;
                path.Add(current);
            }
        }
        
    }
}