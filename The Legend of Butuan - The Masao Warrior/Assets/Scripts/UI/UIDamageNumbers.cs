using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDamageNumbers : MonoBehaviour {

	public static UIDamageNumbers Instance;
	public GameObject DamageNumberPrefab;
	RectTransform rectTransform;
	 void Awake() 
	 {
		 Instance = this;
		 rectTransform = GetComponent<RectTransform>();
	 }

	 public void ShowDamageNumber( float damage, Vector3 worldPosition)
	 {
		GameObject newDamageNumberObject = Instantiate<GameObject>(DamageNumberPrefab);
		newDamageNumberObject.transform.GetChild(0).GetComponent<Text>().text = Mathf.RoundToInt( damage ).ToString();
		Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
		RectTransform damageNumberTransform =  newDamageNumberObject.GetComponent<RectTransform>();

		damageNumberTransform.SetParent( transform, true);
		damageNumberTransform.localScale = Vector3.one;
		damageNumberTransform.anchoredPosition = new Vector2(screenPosition.x * rectTransform.rect.width, screenPosition.y * rectTransform.rect.height);
		 

		
		damageNumberTransform.anchoredPosition = screenPosition;
		Destroy(newDamageNumberObject, 1f);

	 }

}
