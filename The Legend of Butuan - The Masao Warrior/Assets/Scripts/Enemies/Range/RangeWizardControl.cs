using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWizardControl : CharacterBaseControl {

	public float chargeTime;
	public float coolDown = 5f;
	public GameObject ballPrefab;

	private GameObject characterInRange;
	private AttackableEnemy attackable;

	public void SetCharacterInRange(GameObject characterInRange) {
		this.characterInRange = characterInRange;
		GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
		StartCoroutine(FollowBall(ball, characterInRange));
	}

	IEnumerator FollowBall(GameObject ball, GameObject characterInRange) {
		yield return new WaitForSeconds(2f);
		ball.GetComponent<BallControl>().SetCharacterInRange(characterInRange);
		StartCoroutine(DestroyBall(ball, coolDown));
	}

	IEnumerator DestroyBall(GameObject ball, float coolDown) {
		yield return new WaitForSeconds(coolDown);
		if(ball != null) {
			ball.GetComponent<BallControl>().attackableEnemy.Kill();	
		}
	}
}
