using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossFigure : Figure
{
    public override void AnimateFigureOnVictory()
    {
        animation = this.gameObject.GetComponent<Animation>();
        animation.Play("CrossRotation");
    }
}
