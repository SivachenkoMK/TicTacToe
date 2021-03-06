﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    protected Animation animation;  
    public void DestroyFigure()
    {
        Destroy(this);
    }

    public virtual void AnimateFigureOnVictory()
    {
        animation = this.gameObject.GetComponent<Animation>();
        animation.Play("CrossRotation");
    }
}
