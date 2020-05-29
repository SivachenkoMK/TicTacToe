using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    public int High;

    public int Length;

    private GameObject Field;

    private GameObject CreatorObject;

    private FigureCreator Creator;

    private void Awake()
    {
        Creator = GameObject.Find("FiguresManager").GetComponent<FigureCreator>();
        Field = GameObject.Find("PhysicalField");
    }

    private void OnMouseDown()
    {
        CreateFigure();
        SetField();
        GameObject.Find("FiguresManager").GetComponent<NeededToCreateFigure>().ChangeForOther();
        Destroy(this.gameObject);
    }

    private void CreateFigure()
    {
        Creator.DoAllForCreation(this.gameObject, GameObject.Find("FiguresManager").GetComponent<NeededToCreateFigure>().NeedForCreation);
    }

    private void SetField()
    {
        if (GameObject.Find("FiguresManager").GetComponent<NeededToCreateFigure>().NeedForCreation == "Cross")
        {
            Field.GetComponent<FiguresOnField>().Field[High, Length] = 1;
        }
        else if (GameObject.Find("FiguresManager").GetComponent<NeededToCreateFigure>().NeedForCreation == "Zero")
        {
            Field.GetComponent<FiguresOnField>().Field[High, Length] = 2;
        }
    }
}
