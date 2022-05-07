using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Transform doorT;
    public Transform openPosition;
    public Transform closePosition;

    public float speed = 1f;
    public bool open = false;

    private void Update()
    {
        if(open)
        {
            doorT.position = Vector3.MoveTowards(doorT.position, openPosition.position, Time.deltaTime * speed);
        }

        if (!open)
        {
            doorT.position = Vector3.MoveTowards(doorT.position, closePosition.position, Time.deltaTime * speed);
        }
    }

    public void CloseOpen()
    {
        open = !open;
    }
}
