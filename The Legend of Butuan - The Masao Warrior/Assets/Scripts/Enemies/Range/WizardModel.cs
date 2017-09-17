using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardModel : RangeBaseControl {

	public GameObject bulletPrefab;
	public float speed;

	private Vector3 movementDirection;
	private Vector3 facingDirection;
	private Rigidbody2D rigidBody;
	private bool isAttacking;
	private bool isSpotted;

	void Awake() {
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void Update() {
		
	}

	void FixedUpdate() {
		UpdateMovement();
	}

	void UpdateMovement() {
		if(FadeManager.instance.IsFading()) {
			rigidBody.velocity = Vector2.zero;
			return;
		}
		if(movementDirection != Vector3.zero) {
			movementDirection.Normalize();
		}
		rigidBody.velocity = movementDirection * speed;
	}

	new public void SetDirection(Vector2 direction) {
		movementDirection = new Vector3(direction.x, direction.y, 0);
		if(direction != Vector2.zero) {
			facingDirection = movementDirection;
		}
	}

	public bool CanAttack() {
		if(isAttacking) {
			return false;
		}
		return true;
	}

	public void DoAttack() {

	}

	public void DoShoot() {
		GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
		bullet.GetComponent<Rigidbody2D>().velocity = GetFacingDirection() * 10;
		Destroy(bullet, 3f);
	}

	public Vector3 GetDirection() {
		return movementDirection;
	}

	public Vector3 GetFacingDirection() {
		return facingDirection;
	}

	public bool IsMoving() {
		return movementDirection != Vector3.zero;
	}

	public void OnAttackStarted() {
		isAttacking = true;
	}

	public void OnAttackFinished() {
		DoShoot();
		isAttacking = false;
	}
}
