using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierMove : MonoBehaviour
{

    private bool action;
    [SerializeField]private float lerpSpeed = 0.3f;
    private float timer;

    void FixedUpdate() {
        timer = Random.Range(2,5);

        if(!action){
            StartCoroutine(Move());
        }
    }

    //Use this to kick off the Action
    IEnumerator Move() {
        action = true;

        gameObject.transform.position = Vector3.Lerp(this.transform.position, RandomVector(), lerpSpeed); 
        yield return new WaitForSeconds(timer);

        //Allow further actions
        action = false;
    }

    private Vector3 RandomVector() {
        var z = Random.Range(-20, 20);
        return new Vector3(this.transform.position.x, this.transform.position.y, z);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}