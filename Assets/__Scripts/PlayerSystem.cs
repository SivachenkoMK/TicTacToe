using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    public Player Player1;
    public Player Player2;
    public int Turn;
    private void Awake()
    {
        SetPlayers();
        Player1.Figure = 'X';
        Player2.Figure = 'O';
        Turn = 1;
    }

    public void Update()
    {
        if (Turn == 1)
        {
            Player1.Move();
        }
        else if (Turn == 2)
        {
            Player2.Move();
        }
    }

    private void SetPlayers()
    {
        SetFirstPlayer();
        SetSecondPlayer();
    }

    private void SetFirstPlayer()
    {
        if (GameSetup.FirstPlayer == "Person")
        {
            Player1 = Player1.gameObject.AddComponent<Person>();
            Destroy(Player1.gameObject.GetComponent<Player>());
        }
        else if (GameSetup.FirstPlayer == "Bot")
        {
            Player1 = Player1.gameObject.AddComponent<Bot>();
            Destroy(Player1.gameObject.GetComponent<Player>());
        }
    }

    private void SetSecondPlayer()
    {
        if (GameSetup.SecondPlayer == "Person")
        {
            Player2 = Player2.gameObject.AddComponent<Person>();
            Destroy(Player2.gameObject.GetComponent<Player>());
        }
        else if (GameSetup.SecondPlayer == "Bot")
        {
            Player2 = Player2.gameObject.AddComponent<Bot>();
            Destroy(Player2.gameObject.GetComponent<Player>());
        }
    }

    public void NextTurn()
    {
        if (Turn == 1)
            Turn++;
        else if (Turn == 2)
            Turn--;
    }
}
