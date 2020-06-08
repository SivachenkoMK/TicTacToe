using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FieldOfGameObjects 
{
    public static GameObject[] Figures = new GameObject[9];

    public static void AnimateWinningRow(int First, int Second, int Third)
    {
        Figures[First].GetComponent<Figure>().AnimateFigureOnVictory();
        Figures[Second].GetComponent<Figure>().AnimateFigureOnVictory();
        Figures[Third].GetComponent<Figure>().AnimateFigureOnVictory();
    }
}
