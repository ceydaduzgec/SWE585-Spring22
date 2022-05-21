using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTreasure : MonoBehaviour {

    [SerializeField]private Text pickUpText;
    private bool pickUpAllowed;
    public AudioSource coinSound;

	// Use this for initialization
	private void Start () {
        pickUpText.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	private void Update () {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        PickUp();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }        
    }
    
    private void OnTriggerExit(Collider collision)
    {
        if(collision.tag == "Player")
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {   
        coinSound.Play();
        Destroy(gameObject);
        pickUpText.gameObject.SetActive(false);
    }

}



