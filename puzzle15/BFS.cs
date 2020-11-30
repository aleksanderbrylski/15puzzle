using System;
using System.Collections.Generic;

namespace puzzle15
{
    public class Bfs
    {
        private readonly List<Node> _openList = new List<Node>(); //nodes that were not visited yet
        private readonly List<Node> _closedList = new List<Node>(); //nodes that were visited
        private readonly List<Node> _pathToSolution  = new List<Node>();
        private string _order;
        public Bfs() { }

        public Bfs(string order)
        {
            this._order = order;
        }

        public List<Node> BreathFirstSearch(Node root)
        {
            _openList.Add((root));
            bool isSolved = false;

            while (_openList.Count > 0 && !isSolved)
            {
                //current node is first node from open list
                //it is added to closed list and removed from open list
                Node currentNode = _openList[0];
                _closedList.Add(currentNode);
                _openList.RemoveAt(0);
                
                currentNode.ExpandMove(_order);
                //jakbyś chciał sobie zobaczyć poszczególne ruchy, chociaz i tak nic nie widac bo nie wiadomo ktory po ktorym jest xd Edit: XD dobry feature XD
                //currentNode.PrintPuzzle();
                
                foreach (var currentChild in currentNode.Children)
                {
                    if (currentChild.IsSolved())
                    {
                        Console.WriteLine("Success ;)");
                        isSolved = true;
                        
                        //trace path to root node
                        PathTrace(_pathToSolution, currentChild);
                    }
                    
                    //Checks if openList or closed list contains currentChild
                    if (!Contains(_openList, currentChild) && !Contains(_closedList, currentChild))
                    {
                        _openList.Add(currentChild);
                    }
                }
                
            }
            _pathToSolution.Reverse();
            return _pathToSolution;
        }

        private static bool Contains(List<Node> list, Node n)
        {
            bool contains = false;

            foreach (var t in list)
            {
                if (t.IsIdentical(n.Puzzle))
                {
                    contains = true;
                }
            }

            return contains;
        }

        private void PathTrace(List<Node> path, Node n)
        {
            Console.WriteLine("Path: ");
            Node current = n;
            path.Add(current);

            while (current.Parent != null)
            {
                current = current.Parent;
                path.Add(current);
            }
        }
        
    }
}