using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void EasyMode()
    {
        SceneManager.LoadScene("EasyMode");
    }
    public void MediumMode()
    {
        SceneManager.LoadScene("MediumMode");
    }
    public void HardMode()
    {
        SceneManager.LoadScene("HardMode");
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
