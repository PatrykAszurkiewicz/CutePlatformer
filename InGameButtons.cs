using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InGameButtons : MonoBehaviour
{
    public void RestartujGre()
    {
        SceneManager.LoadScene("GraScena");
    }
    public void PauseMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
