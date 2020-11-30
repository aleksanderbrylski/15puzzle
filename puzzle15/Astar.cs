using System;
using System.Collections.Generic;

namespace puzzle15
{
    public class Astar
    {
        private readonly List<Node> _openList = new List<Node>();
        private readonly List<Node> _closedList = new List<Node>(); 
        private readonly List<Node> _pathToSolution  = new List<Node>();
        public Astar() { }

        public List<Node> AStar(Node root)
        {
            _openList.Add(root);
            bool isSolved = false;

            while (_openList.Count > 0 && !isSolved)
            {
                Node currentNode = FindTheBestNode(_openList);
                _closedList.Add(currentNode);
                _openList.Remove(currentNode);
                
                currentNode.ExpandMove();

                foreach (var currentChild in currentNode.Children)
                {
                    if (currentChild.IsSolved())
                    {
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

        private Node FindTheBestNode(List<Node> list)
        {
            Node node = list[0];
            foreach (var t in list)
            {
                if (t.F < node.F)
                {
                    node = t;
                }
            }

            return node;
        }

        private void PathTrace(List<Node> path, Node n)
        {
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