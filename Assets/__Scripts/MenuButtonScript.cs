using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonScript : MonoBehaviour
{
    public GameObject Menu;

    public void OpenMenu()
    {
        Menu.SetActive(true);
    }
}
