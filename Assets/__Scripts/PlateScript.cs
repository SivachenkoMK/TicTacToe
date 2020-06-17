 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    public int number;

    public void OnMouseDown()
    {
        Field.TryMoving(this.number);
    }
}
