using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezer : PickUp
{
    public int freezeTime = 10;

    public override void Picked()
    {
        GameManager.gameManager.FreezeTime(freezeTime);
        GameManager.gameManager.PlayClip(pickedClip);
        Destroy(this.gameObject);
    }
}