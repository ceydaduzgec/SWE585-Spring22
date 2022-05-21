using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

	public GameObject objectPrefab;
    public GameObject objectPrefab2;
    public GameObject objectPrefab3;
    public GameObject cubePrefab;
    public GameObject cubePrefab2;
    public GameObject cubePrefab3;
	public float respawnTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(circleWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator circleWave() {

        while(true) {
            yield return new WaitForSeconds(respawnTime);
            spawnircle();
            spawnCube();
        }

    }

    private void spawnircle() {
    	GameObject a = Instantiate(objectPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-5, 5), Random.Range(0, 5));
        Rigidbody rb = a.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
/*
        GameObject b = Instantiate(objectPrefab2) as GameObject;
        b.transform.position = new Vector2(Random.Range(-5, 5), Random.Range(0, 5));
        Rigidbody rbb = b.GetComponent<Rigidbody>();
        rbb.velocity = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));

        GameObject c = Instantiate(objectPrefab3) as GameObject;
        c.transform.position = new Vector2(Random.Range(-5, 5), Random.Range(0, 5));
        Rigidbody rbc = c.GetComponent<Rigidbody>();
        rbc.velocity = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
*/
    }

    private void spawnCube() {
        GameObject a = Instantiate(cubePrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-5, 5), Random.Range(0, 5));
        Rigidbody rb = a.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));

/*
        GameObject b = Instantiate(cubePrefab2) as GameObject;
        b.transform.position = new Vector2(Random.Range(-5, 5), Random.Range(0, 5));
        Rigidbody rbb = b.GetComponent<Rigidbody>();
        rbb.velocity = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));

        GameObject c = Instantiate(cubePrefab3) as GameObject;
        c.transform.position = new Vector2(Random.Range(-5, 5), Random.Range(0, 5));
        Rigidbody rbc = c.GetComponent<Rigidbody>();
        rbc.velocity = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
*/
    }
}
