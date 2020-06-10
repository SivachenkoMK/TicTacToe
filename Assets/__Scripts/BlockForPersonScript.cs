using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockForPersonScript : MonoBehaviour
{
    GameObject BlockForPerson;

    private void Start()
    {
        BlockForPerson = GameObject.Find("BlockForPerson");
        BlockForPerson.SetActive(false);
    }
    private void Update()
    {
        if (BotsTurn() || GameEnded())
        {
            BlockForPerson.SetActive(true);
        }
        else if (!BotsTurn())
        {
            BlockForPerson.SetActive(false);
        }
    }

    private bool GameEnded()
    {
        if (GameObject.Find("PlayerSystem").GetComponent<PlayerSystem>().Turn == 0)
        {
            return true;
        }
        return false;
    }
    private bool BotsTurn()
    {
        if (GameSetup.FirstPlayer == "Bot" && GameObject.Find("PlayerSystem").GetComponent<PlayerSystem>().Turn == 1)
        {
            return true;
        }
        else if (GameSetup.SecondPlayer == "Bot" && GameObject.Find("PlayerSystem").GetComponent<PlayerSystem>().Turn == 2)
        {
            return true;
        }
        else
            return false;
    }
}
