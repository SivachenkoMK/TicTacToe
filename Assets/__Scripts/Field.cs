using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Field
{
    public static char[] field = { '0', '1', '2', '3', '4', '5', '6', '7', '8' };

    public static int FilledCells = 0;

    public static void SetFieldZero()
    {
        for (int i = 0; i < field.Length; i++)
        {
            field[i] = char.Parse(i.ToString());
        }
    }

    public static void Draw()
    {
        if (FilledCells == field.Length && !CheckForVictory(field, 'X') && !CheckForVictory(field, 'O'))
        {
             GameController _GameController = GameObject.Find("GameController").GetComponent<GameController>();
            _GameController.EndGame("Draw");
        }
    }

    public static void CrossWins()
    {
        if (CheckForVictory(field, 'X'))
        {
            GameController _GameController = GameObject.Find("GameController").GetComponent<GameController>();
            _GameController.EndGame("Cross");
        }
    }

    public static void ZeroWins()
    {
        if (CheckForVictory(field, 'O'))
        {
            GameController _GameController = GameObject.Find("GameController").GetComponent<GameController>();
            _GameController.EndGame("Zero");
        }
    }

    private static bool CheckForVictory(char[] Board, char Player)
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
}
