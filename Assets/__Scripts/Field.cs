using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Field
{
    public static char[] field = { '0', '1', '2', '3', '4', '5', '6', '7', '8' };

    public static int FilledCells = 0;

    public static int FirstField;
    public static int SecondField;
    public static int ThirdField;

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
            GetThree('X', ref FirstField, ref SecondField, ref ThirdField);
            FieldOfGameObjects.AnimateWinningRow(FirstField, SecondField, ThirdField);
            GameController _GameController = GameObject.Find("GameController").GetComponent<GameController>();
            _GameController.EndGame("Cross");
        }
    }

    public static void ZeroWins()
    {
        if (CheckForVictory(field, 'O'))
        {
            GetThree('O', ref FirstField, ref SecondField, ref ThirdField);
            FieldOfGameObjects.AnimateWinningRow(FirstField, SecondField, ThirdField);
            GameController _GameController = GameObject.Find("GameController").GetComponent<GameController>();
            _GameController.EndGame("Zero");
        }
    }

    private static void GetThree(char Player, ref int First, ref int Second, ref int Third)
    {
        if (field[0] == Player && field[1] == Player && field[2] == Player)
        {
            First = 0;
            Second = 1;
            Third = 2;
            return;
        }
        if (field[3] == Player && field[4] == Player && field[5] == Player)
        {
            First = 3;
            Second = 4;
            Third = 5;
            return;
        }
        if (field[6] == Player && field[7] == Player && field[8] == Player)
        {
            First = 6;
            Second = 7;
            Third = 8;
            return;
        }
        if (field[0] == Player && field[3] == Player && field[6] == Player)
        {
            First = 0;
            Second = 3;
            Third = 6;
            return;
        }
        if (field[1] == Player && field[4] == Player && field[7] == Player)
        {
            First = 1;
            Second = 4;
            Third = 7;
            return;
        }
        if (field[2] == Player && field[5] == Player && field[8] == Player)
        {
            First = 2;
            Second = 5;
            Third = 8;
            return;
        }
        if (field[0] == Player && field[4] == Player && field[8] == Player)
        {
            First = 0;
            Second = 4;
            Third = 8;
            return;
        }
        if (field[2] == Player && field[4] == Player && field[6] == Player)
        {
            First = 2;
            Second = 4;
            Third = 6;
            return;
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
