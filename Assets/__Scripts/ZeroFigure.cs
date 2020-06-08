using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroFigure : Figure
{
    public override void AnimateFigureOnVictory()
    {
        animation = this.gameObject.GetComponent<Animation>();
        animation.Play("ZeroRotation");
    }
}
