using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private LevelManager gameLevelManager;
    public int WartoscCoin;

    private void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameLevelManager.AddCoins(WartoscCoin);
            Destroy(gameObject);
        }
    }
}
