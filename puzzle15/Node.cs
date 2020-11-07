using System;
using System.Collections.Generic;

namespace puzzle15
{
    public class Node
    {
        private int _x = 0;
        private const int NumberOfColumns = 4;

        public List<Node> Children { get; set; } = new List<Node>();

        public Node Parent { get; set; }

        public int[] Puzzle { get; set; } = new int[16];

        public Node(int[] puzzle)
        {
            SetPuzzle(puzzle);
        }

        private void SetPuzzle(int[] puzzle)
        {
            for(int i = 0; i < puzzle.Length; i++)
            {
                Puzzle[i] = puzzle[i];
            }
        }

        //Checks if the puzzle is solved
        public bool IsSolved()
        {
            int m = Puzzle[0];

            for (int i = 1; i < Puzzle.Length; i++)
            {
                if (m > Puzzle[i])
                {
                    return false;
                }
                m = Puzzle[i];
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
            for (int i = 0; i < Puzzle.Length; i++)
            {
                if (Puzzle[i] == 0)
                {
                    _x = i;
                    break;
                }
            }
            MoveLeft(Puzzle, _x);
            MoveRight(Puzzle, _x);
            MoveDown(Puzzle, _x);
            MoveUp(Puzzle, _x);
        }
        
        //MOVES
        private void MoveRight(int[] p, int i)
        {
            //Checks if we can move to the right
            if (i % NumberOfColumns >= NumberOfColumns - 1) return;
            //Create a copy of the puzzle so as not to operate on the original puzzle
            int[] puzzleCopy = new int [16];
            CopyPuzzle(puzzleCopy, p);

            //Move to right in CopyPuzzle
            int temp = puzzleCopy[i + 1];
            puzzleCopy[i + 1] = puzzleCopy[i];
            puzzleCopy[i] = temp;
                
            Node child = new Node(puzzleCopy);
            Children.Add(child);
            child.Parent = this;
        }
        
        private void MoveLeft(int[] p, int i)
        {
            //Checks if we can move to the left
            if (i % NumberOfColumns <= 0) return;
            //Create a copy of the puzzle so as not to operate on the original puzzle
            int[] puzzleCopy = new int [16];
            CopyPuzzle(puzzleCopy, p);

            //Move to left in CopyPuzzle
            int temp = puzzleCopy[i - 1];
            puzzleCopy[i - 1] = puzzleCopy[i];
            puzzleCopy[i] = temp;
                
            Node child = new Node(puzzleCopy);
            Children.Add(child);
            child.Parent = this;
        }
        
        private void MoveDown(int[] p, int i)
        {
            //Checks if we can move down
            if (i + NumberOfColumns >= Puzzle.Length) return;
            //Create a copy of the puzzle so as not to operate on the original puzzle
            int[] puzzleCopy = new int [16];
            CopyPuzzle(puzzleCopy, p);

            //Move down in CopyPuzzle
            int temp = puzzleCopy[i + 4];
            puzzleCopy[i + 4] = puzzleCopy[i];
            puzzleCopy[i] = temp;
                
            Node child = new Node(puzzleCopy);
            Children.Add(child);
            child.Parent = this;
        }
        
        private void MoveUp(int[] p, int i)
        {
            //Checks if we can move up
            if (i - NumberOfColumns < 0) return;
            //Create a copy of the puzzle so as not to operate on the original puzzle
            int[] puzzleCopy = new int [16];
            CopyPuzzle(puzzleCopy, p);

            //Move up in CopyPuzzle
            int temp = puzzleCopy[i - 4];
            puzzleCopy[i - 4] = puzzleCopy[i];
            puzzleCopy[i] = temp;
                
            Node child = new Node(puzzleCopy);
            Children.Add(child);
            child.Parent = this;
        }
    }
}