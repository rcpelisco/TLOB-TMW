using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour {

	public static FadeManager instance {get; set;}

	public Image fadeImage;
	public bool fadeOnStart;
	public bool isDestroyOnLoad;
	public float fadeTime = 1.5f;

	private bool isFading;
	private float transition;
	private bool isShowing;
	private float duration;
	private static bool isCanvasExists;

	void Awake () {
		instance = this;
		if(isDestroyOnLoad) {
			return;
		}
		if(!isCanvasExists) {
			isCanvasExists = true;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	void OnLevelWasLoaded() {
		if(fadeOnStart) {
			Fade(false, fadeTime);
		}
	}

	void Start() {
		if(fadeOnStart) {
			Fade(false, fadeTime);
		}
	}
	
	public void Fade(bool showing, float duration) {
		isShowing = showing;
		isFading = true;
		this.duration = duration;
		if(isShowing) {
			transition = 0;
		} else {
			transition = 1;
		}
	}

	void Update() {
		if(!isFading) {
			return;
		}
		if(isShowing) {
			transition += Time.deltaTime * (1/duration);
		} else {
			transition -= Time.deltaTime * (1/duration);
		}
		fadeImage.color = Color.Lerp(new Color(0, 0 ,0 ,0), Color.black, transition);
		if(transition > 1 || transition < 0) {
			isFading = false;
		}
	}

	public bool IsFading() {
		return isFading;
	}
}
