using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Field
{
    public static int[,] field = new int[GameSetup.Height, GameSetup.Length];

    public static int FilledCells = 0;

    public static void SetFieldZero()
    {
        for (int i = 0; i < GameSetup.Length; i++)
        {
            for (int j = 0; j < GameSetup.Height; j++)
            {
                field[i, j] = 0;
            }
        }
    }

    public static void Draw()
    {
        if (FilledCells == GameSetup.Height * GameSetup.Length/* && CheckForVictory() == null*/)
        {
             GameController _GameController = GameObject.Find("GameController").GetComponent<GameController>();
            _GameController.EndGame("Draw");
        }
    }

    public static string CheckForVictory()
    {
        if (CheckForHorizontals() != null)
            return CheckForHorizontals();
        if (CheckForVerticals() != null)
            return CheckForVerticals();
        if (CheckForDiagonals() != null)
            return CheckForDiagonals();
        return null;
    }

    private static string CheckForHorizontals()
    {
        for (int i = 0; i < 3; i++)
        {
            if (field[i, 0] == field[i, 1] && field[i, 1] == field[i, 2])
            {
                switch (field[i, 0])
                {
                    case (1):
                        {
                            return "Cross";
                        }
                    case (2):
                        {
                            return "Zero";
                        }
                    default:
                        {
                            continue;
                        }
                }
            }
        }
        return null; 
    }

    private static string CheckForVerticals()
    {

        for (int j = 0; j < 3; j++)
        {
            if (field[0, j] == field[1, j] && field[1, j] == field[2, j])
            {
                switch (field[0, j])
                {
                    case (1):
                        {
                            return "Cross";
                        }
                    case (2):
                        {
                            return "Zero";
                        }
                    default:
                        {
                            continue;
                        }
                }
            }
        }
        return null;
    }

    private static string CheckForDiagonals()
    {
        if ((field[0, 0] == field[1, 1] && field[1, 1] == field[2, 2]) || (field[2, 0] == field[1, 1] && field[1, 1] == field[0, 2]))
        {
            switch (field[1, 1])
            {
                case (1):
                    {
                        return "Cross";
                    }
                case (2):
                    {
                        return "Zero";
                    }
                default:
                    {
                        break;
                    }
            }
        }
        return null;
    }
}
