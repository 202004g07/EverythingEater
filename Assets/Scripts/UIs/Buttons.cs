using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void OnRetry()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}
