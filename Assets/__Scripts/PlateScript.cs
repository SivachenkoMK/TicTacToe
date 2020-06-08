using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    public int number;

    private FigureCreator Creator;

    private GameController _GameController;

    private void Awake()
    {
        Creator = GameObject.Find("FiguresManager").GetComponent<FigureCreator>();
    }

    public void OnMouseDown()
    {
        _GameController = GameObject.Find("GameController").GetComponent<GameController>();
        Move();
        Destroy(this.gameObject);
    }

    public void Move()
    {
        CreateFigure();
        SetCorrectCellInField();
        Field.FilledCells++;
        if (Field.FilledCells == 1)
            _GameController.CrossMovesFirst.SetActive(false);
        GameObject.Find("PlayerSystem").GetComponent<PlayerSystem>().NextTurn();
        Field.CrossWins();
        Field.ZeroWins();
        Field.Draw();
    }

    private void SetCorrectCellInField()
    {
        Field.field[number] = GetCurrentFigure();
    }

    private void CreateFigure()
    {
        GameObject Figure;
        Figure = Instantiate(Creator.ImagineFigure(this.gameObject, GetCurrentFigure()));
        FieldOfGameObjects.Figures[number] = Figure;
    }

    private char GetCurrentFigure()
    {
        if (GameObject.Find("PlayerSystem").GetComponent<PlayerSystem>().Turn == 1)
            return GameObject.Find("PlayerSystem").GetComponent<PlayerSystem>().Player1.Figure;
        else if (GameObject.Find("PlayerSystem").GetComponent<PlayerSystem>().Turn == 2)
            return GameObject.Find("PlayerSystem").GetComponent<PlayerSystem>().Player2.Figure;
        return ' ';
    }
}
