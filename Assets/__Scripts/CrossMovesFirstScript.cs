using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossMovesFirstScript : MonoBehaviour
{
    private void Update()
    {
        if (Field.FilledCells >= 1)
            GoNotActive();
    }
    public void GoNotActive()
    {
        this.gameObject.SetActive(false);
    }
}
