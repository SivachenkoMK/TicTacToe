using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NeededToCreateFigure
{
    public static string NeedForCreation = "Cross";

    public static void ChangeForOther()
    {
        if (NeedForCreation == "Cross")
            NeedForCreation = "Zero";
        else if (NeedForCreation == "Zero")
            NeedForCreation = "Cross";
    }

    public static void SetNeededForCross()
    {
        NeedForCreation = "Cross";
    }
}
