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
            currentNode.PrintPuzzle();
            //Console.Write(childrenCounter);
            if (currentNode.IsSolved())
            {
                _pathToSolution.Add(currentNode);
                Console.Write("jebać pis");
                return true;
            }
            _visitedNodes.Add(currentNode);

            if (!foundSolved && currentNode.MoveLeft() && !Contains(_visitedNodes, currentNode.Children[childrenCounter]))
            {
                foundSolved = FindFittingNode(currentNode.Children[childrenCounter]);
                childrenCounter++;
            }
            if (!foundSolved && currentNode.MoveRight() && !Contains(_visitedNodes, currentNode.Children[childrenCounter]))
            {
                //currentNode.Children[childrenCounter].PrintPuzzle();
                Console.Write("in right");
                foundSolved = FindFittingNode(currentNode.Children[childrenCounter]);
                childrenCounter++;
            }
            if (!foundSolved && currentNode.MoveUp() && !Contains(_visitedNodes, currentNode.Children[childrenCounter]))
            {
                Console.Write("in up");
                foundSolved = FindFittingNode(currentNode.Children[childrenCounter]);
                childrenCounter++;
            }
            if (!foundSolved && currentNode.MoveDown() && !Contains(_visitedNodes, currentNode.Children[childrenCounter]))
            {
                foundSolved = FindFittingNode(currentNode.Children[childrenCounter]);
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