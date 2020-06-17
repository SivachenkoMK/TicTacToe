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

    public static GameObject[] ObjectFigures = new GameObject[9];

    public static void AnimateWinningRow(int First, int Second, int Third)
    {
        ObjectFigures[First].GetComponent<Figure>().AnimateFigureOnVictory();
        ObjectFigures[Second].GetComponent<Figure>().AnimateFigureOnVictory();
        ObjectFigures[Third].GetComponent<Figure>().AnimateFigureOnVictory();
    }

    public static void SetFieldZero()
    {
        for (int i = 0; i < field.Length; i++)
        {
            field[i] = char.Parse(i.ToString());
        }
    }

    public static void TryEndingGame()
    {
        TryEndingGameWithCrossVictory();
        TryEndingGameWithZeroVictory();
        TryEndingGameWithDraw();
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

    public static void TryEndingGameWithDraw()
    {
        if (FilledCells == field.Length && !CheckForVictory(field, 'X') && !CheckForVictory(field, 'O'))
        {
             GameController _GameController = GameObject.Find("GameController").GetComponent<GameController>();
            _GameController.EndGame("Draw");
        }
    }

    public static void TryEndingGameWithCrossVictory()
    {
        if (CheckForVictory(field, 'X'))
        {
            GetThree('X', ref FirstField, ref SecondField, ref ThirdField);
            AnimateWinningRow(FirstField, SecondField, ThirdField);
            GameController _GameController = GameObject.Find("GameController").GetComponent<GameController>();
            _GameController.EndGame("Cross");
        }
    }

    public static void TryEndingGameWithZeroVictory()
    {
        if (CheckForVictory(field, 'O'))
        {
            GetThree('O', ref FirstField, ref SecondField, ref ThirdField);
            AnimateWinningRow(FirstField, SecondField, ThirdField);
            GameController _GameController = GameObject.Find("GameController").GetComponent<GameController>();
            _GameController.EndGame("Zero");
        }
    }

    public static void TryMoving(int NumberOfCell)
    {
        if (IsCurrentCellEmpty(NumberOfCell) && GameObject.Find("PlayerSystem").GetComponent<PlayerSystem>().Turn != 0)
        {
            DoMove(NumberOfCell);
        }
        else
        {
            // Можно будет добавить табличку по типу: данная клетка занята.
        }
    }

    private static bool IsCurrentCellEmpty(int NumberOfCell)
    {
        if (field[NumberOfCell] != 'X' && field[NumberOfCell] != 'O')
            return true;
        return false;
    }

    private static void DoMove(int NumberOfCell)
    {
        FilledCells++;
        field[NumberOfCell] = GameObject.Find("PlayerSystem").GetComponent<PlayerSystem>().GetCurrentFigure();
        CreateFigureObject(NumberOfCell);
        GameObject.Find("PlayerSystem").GetComponent<PlayerSystem>().NextTurn();
        TryEndingGame();
    }

    private static void CreateFigureObject(int NumberOfCell)
    {
        GameObject NeededForCreationObjectedFigure = GetNeededForCreationFigure();
        ObjectFigures[NumberOfCell] = GameObject.Instantiate(NeededForCreationObjectedFigure, GetPositionWhereFigureMustBeStoraged(NumberOfCell), Quaternion.identity);
    }

    private static GameObject GetNeededForCreationFigure()
    {
        if (GameObject.Find("PlayerSystem").GetComponent<PlayerSystem>().GetCurrentFigure() == 'X')
            return GameObject.Find("FiguresManager").GetComponent<FigureCreator>().Cross;
        else if (GameObject.Find("PlayerSystem").GetComponent<PlayerSystem>().GetCurrentFigure() == 'O')
            return GameObject.Find("FiguresManager").GetComponent<FigureCreator>().Zero;
        else
        {
            Debug.LogError("Incorrect NumberOfCell or field[NumberOfCell] is not filled");
            return null;
        }
    }

    private static Vector3 GetPositionWhereFigureMustBeStoraged(int NumberOfCell)
    {
        return NeededPlate(NumberOfCell).transform.position;
    }

    private static GameObject NeededPlate(int NumberOfCell)
    {
        GameObject[] Plates = GameObject.FindGameObjectsWithTag("Plate");
        foreach (GameObject plate in Plates)
        {
            if (plate.GetComponent<PlateScript>().number == NumberOfCell)
            {
                return plate;
            }
        }
        return null;
    }
}
