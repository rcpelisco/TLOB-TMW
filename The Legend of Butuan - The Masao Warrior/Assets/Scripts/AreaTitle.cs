using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaTitle : MonoBehaviour {

	private Animator anim;
	private GameObject title;
	private Text minimapTitle;
	private string areaTitle;

	void Awake() {
		anim = GetComponentInChildren<Animator>();
		minimapTitle = GameObject.FindGameObjectWithTag("AreaTitle").GetComponent<Text>();
		areaTitle = GetComponentInChildren<Text>().text;
		minimapTitle.text = areaTitle;
		title = anim.gameObject;
		title.SetActive(false);
		StartCoroutine(Show());
	}

	IEnumerator Show() {
		yield return new WaitForSeconds(.5f);
		title.SetActive(true);
		StartCoroutine(Hide());
	}

	IEnumerator Hide() {
		yield return new WaitForSeconds(2.75f);
		anim.SetBool("Hide", true);
	}
}
