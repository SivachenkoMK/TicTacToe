using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWithFriend : MonoBehaviour
{
    public void SetPVPState()
    {
        GameSetup.FirstPlayer = "Person";
        GameSetup.SecondPlayer = "Person";
    }
}
