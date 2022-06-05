using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		AudioPlayerManager.Instance.PlayMusic();
	}
}
