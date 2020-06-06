using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayWithBot : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (this.CompareTag("Cross"))
        {
            GameSetup.FirstPlayer = "Player";
            GameSetup.SecondPlayer = "Bot";
        }
        else if (this.CompareTag("Zero"))
        {
            GameSetup.FirstPlayer = "Bot";
            GameSetup.SecondPlayer = "Player";
        }
        SceneManager.LoadScene("GameScene");
    }
}
