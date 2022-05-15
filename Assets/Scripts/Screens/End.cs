using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public void Home()
    {
        SceneManager.LoadScene("Lobby");
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }

    public void RestartCustom()
    {
        SceneManager.LoadScene("LoadLevel");
        Time.timeScale = 1f;
    }
}
