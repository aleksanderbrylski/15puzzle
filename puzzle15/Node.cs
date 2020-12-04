using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace puzzle15
{
    public class Node
    {
        public readonly int _zeroIndex = 0;
        private const int NumberOfColumns = 4;

        private bool _isInfomed = false;
        
        public int F { get; set; }

        private int Depth { get; set; }

        public List<Node> Children { get; set; } = new List<Node>();

        public Node Parent { get; set; }

        public int[] Puzzle { get; set; } = new int[16];

        //Constructor for DFS and BFS
        public Node(int[] puzzle)
        {
            SetPuzzle(puzzle);
            _zeroIndex = FindZeroIndex();
        }

        //Constructor for Astar
        public Node(int[] puzzle, int depth)
        {
            SetPuzzle(puzzle);
            _zeroIndex = FindZeroIndex();
            Depth = depth;
            F = CalculateF();
            _isInfomed = true;
        }

        private void SetPuzzle(int[] puzzle)
        {
            for(int i = 0; i < puzzle.Length; i++)
            {
                Puzzle[i] = puzzle[i];
            }
        }

        private int FindZeroIndex()
        {
            int tempIndex = 0;
            for (int i = 0; i < Puzzle.Length; i++)
            {
                if (Puzzle[i] == 0)
                {
                    tempIndex = i;
                    break;
                }
            }

            return tempIndex;
        }

        //Checks if the puzzle is solved
        public bool IsSolved()
        {
            for (int i = 0; i < Puzzle.Length; i++)
            {
                if ((i + 1) % 16 != Puzzle[i])
                {
                    return false;
                }
            }
            return true;
        }

        //Creates a copy of the puzzle
        private void CopyPuzzle(int[] a, int[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                a[i] = b[i];
            }
        }

        public void PrintPuzzle()
        {
            Console.WriteLine();

            for (int i = 0; i < NumberOfColumns; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    Console.Write(Puzzle[i * 4 + j] + " ");
                }
                Console.WriteLine();
            }
        }

        //Check if the given puzzle is the same as object's puzzle        
        public bool IsIdentical(int[] puzzleToCheck)
        {
            for (int i = 1; i < puzzleToCheck.Length; i++)
            {
                if (Puzzle[i] != puzzleToCheck[i])
                {
                    return false;
                }
            }
            return true;
        }

        public void ExpandMove()
        {
            MoveLeft();
            MoveRight();
            MoveDown();
            MoveUp();
        }

        public void ExpandMove(string order)
        {
            if (order.Length == 4)
            {
                foreach (char orderItem in order)
                {
                    if (orderItem == 'L')
                    {
                        MoveLeft();
                    } else if (orderItem == 'R')
                    {
                        MoveRight();
                    } else if (orderItem == 'U')
                    {
                        MoveUp();
                    } else
                    {
                        MoveDown();
                    }
                }
            }
            else
            {
                MoveLeft();
                MoveRight();
                MoveDown();
                MoveUp();
            }
        }
        
        //MOVES
        public bool MoveRight()
        {
            //Checks if we can move to the right
            int i = _zeroIndex;
            //Console.Write("Zero index: "+_zeroIndex);
            if (i % NumberOfColumns >= NumberOfColumns - 1) return false;
            //Create a copy of the puzzle so as not to operate on the original puzzle
            //Console.Write("In MoveRight");
            int[] puzzleCopy = new int [16];
            CopyPuzzle(puzzleCopy, Puzzle);

            //Move to right in CopyPuzzle
            int temp = puzzleCopy[i + 1];
            puzzleCopy[i + 1] = puzzleCopy[i];
            puzzleCopy[i] = temp;

            AddChildren(puzzleCopy);
            return true;
        }
        
        public bool MoveLeft()
        {
            int i = _zeroIndex;
            //Checks if we can move to the left
            if (i % NumberOfColumns <= 0) return false;
            //Create a copy of the puzzle so as not to operate on the original puzzle
            int[] puzzleCopy = new int [16];
            CopyPuzzle(puzzleCopy, Puzzle);

            //Move to left in CopyPuzzle
            int temp = puzzleCopy[i - 1];
            puzzleCopy[i - 1] = puzzleCopy[i];
            puzzleCopy[i] = temp;
                
            AddChildren(puzzleCopy);
            return true;
        }
        
        public bool MoveDown()
        {
            int i = _zeroIndex;
            //Checks if we can move down
            if (i + NumberOfColumns >= Puzzle.Length) return false;
            //Create a copy of the puzzle so as not to operate on the original puzzle
            int[] puzzleCopy = new int [16];
            CopyPuzzle(puzzleCopy, Puzzle);

            //Move down in CopyPuzzle
            int temp = puzzleCopy[i + 4];
            puzzleCopy[i + 4] = puzzleCopy[i];
            puzzleCopy[i] = temp;
                
            AddChildren(puzzleCopy);
            return true;
        }

        public bool MoveUp()
        {
            int i = _zeroIndex;
            //Checks if we can move up
            if (i - NumberOfColumns < 0) return false;
            //Create a copy of the puzzle so as not to operate on the original puzzle
            int[] puzzleCopy = new int [16];
            CopyPuzzle(puzzleCopy, Puzzle);

            //Move up in CopyPuzzle
            int temp = puzzleCopy[i - 4];
            puzzleCopy[i - 4] = puzzleCopy[i];
            puzzleCopy[i] = temp;

            AddChildren(puzzleCopy);
            return true;
        }


        private int CalculateF()
        {
            int value = 0;
            if (IsSolved())
            {
                return value;
            }

            for (int i = 0; i < Puzzle.Length; i++)
            {
                if ((i + 1) % 16 != Puzzle[i])
                {
                    value++;
                }
            }
            return value + Depth;
        }

        public void AddChildren(int [] puzzleCopy)
        {
            if (_isInfomed)
            {
                Node child = new Node(puzzleCopy, Depth + 1);
                Children.Add(child);
                child.Parent = this;
            }
            else
            {
                Node child = new Node(puzzleCopy);
                Children.Add(child);
                child.Parent = this;
            }
        }
        
    }
}