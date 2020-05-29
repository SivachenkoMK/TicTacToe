using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeededToCreateFigure : MonoBehaviour
{
    public string NeedForCreation = "Cross";

    public void ChangeForOther()
    {
        if (NeedForCreation == "Cross")
            NeedForCreation = "Zero";
        else if (NeedForCreation == "Zero")
            NeedForCreation = "Cross";
    }
}
