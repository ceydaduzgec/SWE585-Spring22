using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerManager : MonoBehaviour
{
    private AudioSource _source;
	public AudioClip music;

	private bool isPlaying;

    public static AudioPlayerManager Instance;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this);
		}
		else
		{
			Instance = this;
		}

	}

	// Start is called before the first frame update
	void Start()
    {
        _source = GetComponent<AudioSource>();
		_source.clip = music;
		isPlaying = false;
		PlayMusic();
	}


	public void PlayMusic()
	{
		if (isPlaying) return;
		_source.Play();
		isPlaying = true;
	}


	public void StopMusic()
	{
		_source.Stop();
		isPlaying = false;

	}
	
	public void PlaySound(AudioClip sfx)
	{
		_source.PlayOneShot(sfx);
	}


}
