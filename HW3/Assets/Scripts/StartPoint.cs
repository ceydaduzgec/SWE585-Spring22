using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPoint : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player" && GameObject.Find("Treasure") == null){
            FindObjectOfType<GameManager>().EndGame();
            SceneManager.LoadScene("StartMenu");
        }
    }
}
