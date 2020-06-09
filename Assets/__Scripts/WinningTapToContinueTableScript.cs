using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningTapToContinueTableScript : MonoBehaviour
{
    public string Winner;

    private int Counter = 0;

    private int NeededCounter;

    private void SetNeededCounter()
    {
        if ((GameSetup.SecondPlayer == "Bot" && Winner != "Draw") || GameSetup.FirstPlayer == "Bot")
            NeededCounter = 1;
        else
            NeededCounter = 2;
    }
    public void Update()
    {
        SetNeededCounter();
        if (Input.anyKeyDown)
        {
            Counter++;
            if (Counter == NeededCounter)
            {
                GameObject.Find("GameController").GetComponent<GameController>().CreateEndTable(Winner);
                Counter = 0;
                this.gameObject.SetActive(false);
            }
        }
    }
}
