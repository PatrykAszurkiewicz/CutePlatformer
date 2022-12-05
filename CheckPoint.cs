using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Sprite OrangeFlower;
    public Sprite WhiteFlower;

    private SpriteRenderer CheckPointSpriteRenderer;
    public bool checkpointReached;

    private void Start()
    {
        CheckPointSpriteRenderer = GetComponent<SpriteRenderer>();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            CheckPointSpriteRenderer.sprite = WhiteFlower;
            checkpointReached = true;
        }
    }


}
