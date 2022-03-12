using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    public bool addTime;
    public int time = 5;

    public override void Picked()
    {
        if(addTime)
            GameManager.gameManager.AddTime(time);
        else
            GameManager.gameManager.AddTime(time*(-1));
        Destroy(this.gameObject);
    }
}
