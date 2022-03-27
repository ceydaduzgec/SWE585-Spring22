using System;
using UnityEngine;

public class Spawn : MonoBehaviour {
    
	public Transform spawnPos;
	public GameObject spawnee;
	
	void Update () {
		if(Input.GetButtonDown("Jump")) {
			Instantiate(spawnee, spawnPos.position, spawnPos.rotation);
		}
	}
}