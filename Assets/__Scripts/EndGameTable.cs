using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTable : MonoBehaviour
{
    public void DestroyTable()
    {
        Destroy(this.gameObject);
    }

    public void GoToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
