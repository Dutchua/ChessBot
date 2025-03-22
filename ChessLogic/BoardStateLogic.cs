using System;
using System.ComponentModel;

namespace BoardStateLogic
{
    public class BoardState
    {
        // piece definitions
        const String Pawn = "p";
        const String Rook = "r";
        const String Knight = "n";
        const String bishop = "b";
        const String King = "k";
        const String Queen = "q";

        //initial states in both required formats
        readonly String FENstringStart = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";
        //char[,] InitialStateArray = new char[8,8];
        public char[,] InitialState = 
            {{'r', 'n', 'b', 'q', 'k', 'b', 'n', 'r'},
            {'p', 'p', 'p', 'p', 'p', 'p', 'p', 'p'},
            {'.', '.', '.', '.', '.', '.', '.', '.'},
            {'.', '.', '.', '.', '.', '.', '.', '.'},
            {'.', '.', '.', '.', '.', '.', '.', '.'},
            {'.', '.', '.', '.', '.', '.', '.', '.'},
            {'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P'},
            {'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R'}};

        public char[,] CurrentState = {};

        public void CurrnetPos()
        {
            foreach(char i in InitialState)
            {
                Console.WriteLine(i);
            }
        }
        //iterates over fen string and converts it into equivalent board state
        public void FENtoBoardState()
        {
            char[] numbers = ['1','2','3','4','5','6','7','8']; 
            char[,] InitialStateArray = new char[8,8];
            char[,] CurrentState = InitialStateArray;
            String FENstring = FENstringStart;
            int rankIndex = 0;
            int fileIndex = 0;
            //loop over FEN string
            for(int i = 0; i < FENstring.Length; i ++)
            {
                if(rankIndex == 7 && fileIndex == 7)
                {
                    CurrentState[rankIndex, fileIndex] = FENstring[i];
                    break;
                }
                if(numbers.Contains(FENstring[i]))
                {
                    //checks for numbers in FEN string and returns blanks on the relevant position
                    for(int j = 0; j < Convert.ToInt32(FENstring[i]) - '0' ; j++)
                    {
                        CurrentState[rankIndex, fileIndex] = '.';
                        fileIndex++;
                    }
                    if (fileIndex == 8)
                    {
                        continue;
                    }
                }
                if(FENstring[i].Equals('/'))
                {
                    rankIndex++;
                    fileIndex = 0;
                }
                else
                {
                    // Add the piece to the relevant position in the board state array.
                    CurrentState[rankIndex, fileIndex] = FENstring[i];
                    if(fileIndex >= 7)
                    {
                        fileIndex = 0;
                    }
                    else
                    {
                        fileIndex++;
                    }
                }   
            }
            BoardStateDisplay(CurrentState);
            Console.ReadKey();
        }

        public void BoardStatetoFEN()
        {

        }
        //output current board state to console
        public void BoardStateDisplay(char[,] CurrentState)
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    Console.Write($"{CurrentState[i, j]}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
    
}