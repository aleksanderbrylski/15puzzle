using System;
using System.Collections.Generic;

namespace puzzle15
{
    public class Ids
    {
        private List<Node> _visitedNodes = new List<Node>();
        private List<Node> _pathToSolution = new List<Node>();
        
        public Ids()
        {
        }
        
        public List<Node> IterativeDeepingSearch(Node root, int maxDepth)
        {
            bool foundFittingNode = false;
            for (int i = 0; i <= maxDepth; i++)
            {
                _visitedNodes.Clear();
                foundFittingNode = FindFittingNode(root, i);
            }
            if (foundFittingNode)
            {
                _pathToSolution.Reverse();
                Console.Write("The solution was found!");
            }
            return _pathToSolution;
        }

        public bool FindFittingNode(Node currentNode, int limit)
        {
            bool foundSolved = false;
            if (currentNode.IsSolved())
            {
                _pathToSolution.Add(currentNode);
                return true;
            }
            _visitedNodes.Add(currentNode);
            if (limit <= 0)
            {
                return false;
            }
            currentNode.ExpandMove();
            foreach (var currentChild in currentNode.Children)
            {
                if (!Contains(_visitedNodes, currentChild))
                {
                    foundSolved = FindFittingNode(currentChild, limit - 1);
                
                }

                if (foundSolved)
                {
                    _pathToSolution.Add(currentNode);
                    break;
                }
            }
            return foundSolved;
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
    }
}