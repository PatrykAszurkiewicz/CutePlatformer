using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Teleportation : MonoBehaviour
{
    public GameObject Portal;
    public GameObject Player;

    public float timeLeft;
        public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                Teleport();
                timeLeft = 2;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        timeLeft = 2;
    }
    void Teleport()
    {   
        Player.transform.position = new Vector2(Portal.transform.position.x, Portal.transform.position.y);
    }


}
