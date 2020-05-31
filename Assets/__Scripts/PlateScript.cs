using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    public int High;

    public int Length;

    private FigureCreator Creator;

    private GameController _GameController;

    private void Awake()
    {
        Creator = GameObject.Find("FiguresManager").GetComponent<FigureCreator>();
    }

    private void OnMouseDown()
    {
        _GameController = GameObject.Find("GameController").GetComponent<GameController>();
        Move();
        Destroy(this.gameObject);
    }

    private void Move()
    {
        CreateFigure();
        SetCorrectCellInField();
        Field.FilledCells++;
        if (Field.FilledCells == 1)
            _GameController.CrossMovesFirst.SetActive(false); 
        NeededToCreateFigure.ChangeForOther();
        WinGame();
        Field.Draw();
    }

    private void WinGame()
    {
        if (Field.CheckForVictory() != null)
        {
            _GameController = GameObject.Find("GameController").GetComponent<GameController>();
            _GameController.EndGame(Field.CheckForVictory());
        }
    }

    private void SetCorrectCellInField()
    {
        if (NeededToCreateFigure.NeedForCreation == "Cross")
            Field.field[High, Length] = 1;
        else if (NeededToCreateFigure.NeedForCreation == "Zero")
            Field.field[High, Length] = 2;
        else
            Field.field[High, Length] = 0;
    }

    private void CreateFigure()
    {
        Instantiate(Creator.ImagineFigure(this.gameObject, NeededToCreateFigure.NeedForCreation));
    }
}
