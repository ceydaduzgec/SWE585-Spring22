using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public void EndGame()
    {
        if(gameHasEnded== false) 
        {
            Debug.Log("GameOver!");
            gameHasEnded= true;
            Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("StartMenu"); //SceneManager.GetActiveScene().name
    }
}
