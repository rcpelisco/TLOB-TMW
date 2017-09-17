using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicOnLoad : MonoBehaviour {

	public AudioClip newTrack;
	private AudioManager am;

	// Use this for initialization
	void Start () {
		am = FindObjectOfType<AudioManager>();

		if(newTrack != null)
			am.ChangeBGM(newTrack);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
