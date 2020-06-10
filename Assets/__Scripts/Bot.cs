using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Move
{
    public char index;
    public int score;
}


public class Bot : Player
{
    public char huPlayer;
    public char aiPlayer;

    private void Start()
    {
        aiPlayer = Figure;
        if (aiPlayer == 'X')
            huPlayer = 'O';
        else if (aiPlayer == 'O')
            huPlayer = 'X'; 
    }

    public override void Move()
    {
        int Index = int.Parse(Minimax(aiPlayer, Field.field).index.ToString());
        GameObject[] Plates = GameObject.FindGameObjectsWithTag("Plate");
        foreach (GameObject Plate in Plates)
        {
            if (Plate.GetComponent<PlateScript>().number == Index)
            {
                Plate.GetComponent<PlateScript>().OnMouseDown();
            }
        }
    }
    private bool Wins(char[] Board, char Player)
    {
        if ((Board[0] == Player && Board[1] == Player && Board[2] == Player) ||
            (Board[3] == Player && Board[4] == Player && Board[5] == Player) ||
            (Board[6] == Player && Board[7] == Player && Board[8] == Player) ||
            (Board[0] == Player && Board[3] == Player && Board[6] == Player) ||
            (Board[1] == Player && Board[4] == Player && Board[7] == Player) ||
            (Board[2] == Player && Board[5] == Player && Board[8] == Player) ||
            (Board[0] == Player && Board[4] == Player && Board[8] == Player) ||
            (Board[2] == Player && Board[4] == Player && Board[6] == Player))
            return true;
        return false;
    }

    private char[] EmptyIndexies(char[] Board)
    {
        int counter = 0;
        for (int i = 0; i < Board.Length; i++)
        {
            if (Board[i] != 'X' && Board[i] != 'O')
            {
                counter++;
            }
        }
        char[] newBoard = new char[counter];
        counter = 0;
        for (int i = 0; i < Board.Length; i++)
        {
            if (Board[i] != 'X' && Board[i] != 'O')
            {
                newBoard[counter] = Board[i];
                counter++;
            }
        }
        return newBoard;
    }

    public Move Minimax(char player, char[] newBoard)
    {
        char[] AvailSpots = EmptyIndexies(newBoard);

        if (Wins(newBoard, aiPlayer))
        {
            Move move = new Move { score = 10 };
            return move;
        }

        else if (Wins(newBoard, huPlayer))
        {
            Move move = new Move { score = -10 };
            return move;
        }

        else if (EmptyIndexies(newBoard).Length == 0)
        {
            Move move = new Move { score = 0 };
            return move;
        }

        List<Move> moves = new List<Move>();

        for (int i = 0; i < AvailSpots.Length; i++)
        {
            Move move = new Move();
            move.index = newBoard[int.Parse(AvailSpots[i].ToString())];

            newBoard[int.Parse(AvailSpots[i].ToString())] = player;

            if (player == aiPlayer)
            {
                Move result = Minimax(huPlayer, newBoard);
                move.score = result.score;
            }

            else
            {
                Move result = Minimax(aiPlayer, newBoard);
                move.score = result.score;
            }

            newBoard[int.Parse(AvailSpots[i].ToString())] = move.index;
            moves.Add(move);
        }

        int bestMove = -1;

        if (player == aiPlayer)
        {
            int BestScore;
            BestScore = -10000;
            for (int i = 0; i < moves.Count; i++)
            {
                if (moves[i].score > BestScore)
                {
                    BestScore = moves[i].score;
                    bestMove = i;

                }
            }
        }

        else
        {
            int BestScore;
            BestScore = 10000;
            for (var i = 0; i < moves.Count; i++)
            {
                if (moves[i].score < BestScore)
                {
                    BestScore = moves[i].score;
                    bestMove = i;
                }
            }
        }

        return moves[bestMove];
    }
}
