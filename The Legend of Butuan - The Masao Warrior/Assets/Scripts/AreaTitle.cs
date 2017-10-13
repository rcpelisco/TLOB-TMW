using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTitle : MonoBehaviour {

	private Animator anim;
	private GameObject title;
	private 

	void Awake() {
		anim = GetComponentInChildren<Animator>();
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
