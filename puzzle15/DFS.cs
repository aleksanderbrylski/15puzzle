using System;
using System.Collections.Generic;

namespace puzzle15
{
    public class Dfs
    {
        private List<Node> _visitedNodes = new List<Node>();
        private List<Node> _pathToSolution = new List<Node>();
        private string _order;
        
        public Dfs() {}
        
        public Dfs(string order)
        {
            this._order = order;
        }

        public List<Node> DepthFirstSearch(Node root)
        {
            bool foundFittingNode = FindFittingNode(root);
            if (foundFittingNode)
            {
                _pathToSolution.Reverse();
                Console.Write("The solution was found!");
                return _pathToSolution;
            }
            Console.Write("The solution was not found!");
            return _pathToSolution;
        }

        public bool FindFittingNode(Node currentNode)
        {
            bool foundSolved = false;
            if (currentNode.IsSolved())
            {
                _pathToSolution.Add(currentNode);
                return true;
            }
            _visitedNodes.Add(currentNode);
            currentNode.ExpandMove(_order);
            foreach (Node currentChild in currentNode.Children)
            {
                if (!Contains(_visitedNodes, currentChild))
                {
                    foundSolved = FindFittingNode(currentChild);
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