using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureCreator : MonoBehaviour
{
    public GameObject Cross;

    public GameObject Zero;

    public void PutFigureToField()
    {

    }

    public GameObject CreateFigure(GameObject other, string NeededToCreate)
    {
        if (NeededToCreate == "Cross")
            return Instantiate(Cross, other.transform.position, Quaternion.identity);
        else if (NeededToCreate == "Zero")
            return Instantiate(Zero, other.transform.position, Quaternion.identity);
        return null;
    }

    public void DoAllForCreation(GameObject other, string NeededToCreate)
    {
        CreateFigure(other, NeededToCreate);
        PutFigureToField();
    }
}
