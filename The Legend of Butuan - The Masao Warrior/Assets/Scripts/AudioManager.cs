using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource BGM;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeBGM(AudioClip music)
	{
		BGM.Stop();
		BGM.clip = music;
		BGM.Play();
	}
}
