using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningTapToContinueTableScript : MonoBehaviour
{
    public string Winner;

    private int Counter = 0;

    public void Update()
    {
        if (Input.anyKeyDown)
        {
            Counter++;
            if (Counter == 2)
            {
                GameObject.Find("GameController").GetComponent<GameController>().CreateEndTable(Winner);
                Counter = 0;
                this.gameObject.SetActive(false);
            }
        }
    }
}
