using System;
using System.Collections.Generic;

namespace puzzle15
{
    public class Dfs
    {
        private List<Node> _visitedNodes = new List<Node>();
        private List<Node> _pathToSolution = new List<Node>();
        
        public Dfs() {}

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
            int childrenCounter = 0;
            bool foundSolved = false;
            if (currentNode.IsSolved())
            {
                _pathToSolution.Add(currentNode);
                return true;
            }
            _visitedNodes.Add(currentNode);

            if (!foundSolved && currentNode.MoveRight())
            {
                if (!Contains(_visitedNodes, currentNode.Children[childrenCounter]))
                {
                    foundSolved = FindFittingNode(currentNode.Children[childrenCounter]);
                }

                childrenCounter++;
            }
            if (!foundSolved && currentNode.MoveDown())
            {
                if (!Contains(_visitedNodes, currentNode.Children[childrenCounter]))
                {
                    foundSolved = FindFittingNode(currentNode.Children[childrenCounter]);
                }

                childrenCounter++;
            }

            if (!foundSolved && currentNode.MoveLeft())
            {
                if (!Contains(_visitedNodes, currentNode.Children[childrenCounter]))
                {
                    foundSolved = FindFittingNode(currentNode.Children[childrenCounter]);
                }

                childrenCounter++;
            }
            
            if (!foundSolved && currentNode.MoveUp())
            {
                if (!Contains(_visitedNodes, currentNode.Children[childrenCounter]))
                {
                    foundSolved = FindFittingNode(currentNode.Children[childrenCounter]);
                }

                childrenCounter++;
            }
            

            if (foundSolved)
            {
                _pathToSolution.Add(currentNode);
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