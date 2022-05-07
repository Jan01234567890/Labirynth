using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    bool iCanOpen = false;

    public door door;
    public KeyColor myKeyColor;
    bool locked = false;
    Animator key;

    private void Start()
    {
        key = GetComponent<Animator>();
    }

    public void UseKey()
    {
        door.CloseOpen();
    }

    public bool CheckTheKey()
    {
        if(GameManager.gameManager.redKey > 0&& myKeyColor == KeyColor.Red)
        {
            GameManager.gameManager.redKey--;
            locked = true;
            return true;
        } else if (GameManager.gameManager.greenKey > 0 && myKeyColor == KeyColor.Green)
        {
            GameManager.gameManager.greenKey--;
            locked = true;
            return true;
        }
        else if (GameManager.gameManager.goldKey > 0 && myKeyColor == KeyColor.Gold)
        {
            GameManager.gameManager.goldKey--;
            locked = true;
            return true;
        }
        else
        {
            Debug.Log("No key!");
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            iCanOpen = true;
            Debug.Log("Can use lock");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            iCanOpen = false;
            Debug.Log("Can't use lock");
        }
    }
}
