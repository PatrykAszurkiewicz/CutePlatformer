using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelManager: MonoBehaviour
{
    public float respawnDelay;
    public PlayerMovement gamePlayer;
    public int coins;
    public Text coinText;
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerMovement>();
        coinText.text = "Punkty: " + coins;
    }
    public void Respawn()
    {
        StartCoroutine("RespawnTime");
    }
    public IEnumerator RespawnTime()
    {
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.gameObject.SetActive(true);
    }
    public void AddCoins(int liczbaCoins)
    {
        coins += liczbaCoins;
        coinText.text = "Punkty: " + coins;
    }
}

