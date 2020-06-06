using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureCreator : MonoBehaviour
{
    public GameObject Cross;

    public GameObject Zero;

    public GameObject ImagineFigure(GameObject other, char NeededToCreate)
    {
        if (NeededToCreate == 'X')
        {
            Cross.transform.position = other.transform.position;
            return Cross;
        }
        else if (NeededToCreate == 'O')
        {
            Zero.transform.position = other.transform.position;
            return Zero;
        }
        return null;
    }
}
