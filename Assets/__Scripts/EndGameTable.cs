using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTable : MonoBehaviour
{
    public void Restart()
    {
        GameObject.Find("GameController").GetComponent<GameController>().Restart();
    }
}
