using System;
using System.Collections.Generic;

namespace puzzle15
{
    public class Node
    {
        public List<Node> children = new List<Node>();
        public Node parent;
        public int[] puzzle = new int[16];
        private int x = 0;
        private static int numberOfColumns = 4;

        public Node(int[] puzzle)
        {
            SetPuzzle(puzzle);
        }

        public void SetPuzzle(int[] puzzle)
        {
            for (int i = 0; i < puzzle.Length; i++)
            {
                this.puzzle[i] = puzzle[i];
            }
        }

        //Checks if the puzzle is solved
        public bool IsSolved()
        {
            bool isGoal = true;
            int m = puzzle[0];

            for (int i = 1; i < puzzle.Length; i++)
            {
                if (m > puzzle[i])
                {
                    isGoal = false;
                }
                
                m = puzzle[i];
            }

            return isGoal;
        }

        //Creates a copy of the puzzle
        public void CopyPuzzle(int[] a, int[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                a[i] = b[i];
            }
        }

        public void PrintPuzzle()
        {
            Console.WriteLine();

            for (int i = 0; i < numberOfColumns; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    Console.Write(puzzle[i * 4 + j] + " ");
                }
                Console.WriteLine();
            }
        }

        //Check if the given puzzle is the same as object's puzzle        
        public bool IsIdentical(int[] puzzleToCheck)
        {
            bool isIdentical = true;
            for (int i = 1; i < puzzleToCheck.Length; i++)
            {
                if (puzzle[i] != puzzleToCheck[i])
                {
                    isIdentical = false;
                }
            }

            return isIdentical;
        }

        public void ExpandMove()
        {
            for (int i = 0; i < puzzle.Length; i++)
            {
                if (puzzle[i] == 0)
                {
                    x = i;
                }
            }
            
            MoveDown(puzzle, x);
            MoveLeft(puzzle, x);
            MoveRight(puzzle, x);
            MoveUp(puzzle, x);
        }


        //MOVES
        public void MoveRight(int[] p, int i)
        {
            //Checks if we can move to the right
            if (i % numberOfColumns < numberOfColumns - 1)
            {
                //Create a copy of the puzzle so as not to operate on the original puzzle
                int[] puzzleCopy = new int [16];
                CopyPuzzle(puzzleCopy, p);

                //Move to right in CopyPuzzle
                int temp = puzzleCopy[i + 1];
                puzzleCopy[i + 1] = puzzleCopy[i];
                puzzleCopy[i] = temp;
                
                Node child = new Node(puzzleCopy);
                children.Add(child);
                child.parent = this;
            }
        }
        
        public void MoveLeft(int[] p, int i)
        {
            //Checks if we can move to the left
            if (i % numberOfColumns > 0)
            {
                //Create a copy of the puzzle so as not to operate on the original puzzle
                int[] puzzleCopy = new int [16];
                CopyPuzzle(puzzleCopy, p);

                //Move to left in CopyPuzzle
                int temp = puzzleCopy[i - 1];
                puzzleCopy[i - 1] = puzzleCopy[i];
                puzzleCopy[i] = temp;
                
                Node child = new Node(puzzleCopy);
                children.Add(child);
                child.parent = this;
            }
        }
        
        public void MoveDown(int[] p, int i)
        {
            //Checks if we can move down
            if(i + numberOfColumns < puzzle.Length)
            {
                //Create a copy of the puzzle so as not to operate on the original puzzle
                int[] puzzleCopy = new int [16];
                CopyPuzzle(puzzleCopy, p);

                //Move down in CopyPuzzle
                int temp = puzzleCopy[i + 4];
                puzzleCopy[i + 4] = puzzleCopy[i];
                puzzleCopy[i] = temp;
                
                Node child = new Node(puzzleCopy);
                children.Add(child);
                child.parent = this;
            }
        }
        
        public void MoveUp(int[] p, int i)
        {
            //Checks if we can move up
            if (i - numberOfColumns >= 0)
            {
                //Create a copy of the puzzle so as not to operate on the original puzzle
                int[] puzzleCopy = new int [16];
                CopyPuzzle(puzzleCopy, p);

                //Move up in CopyPuzzle
                int temp = puzzleCopy[i - 4];
                puzzleCopy[i - 4] = puzzleCopy[i];
                puzzleCopy[i] = temp;
                
                Node child = new Node(puzzleCopy);
                children.Add(child);
                child.parent = this;
            }
        }
    }
}