using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementModel : CharacterBaseControl {
	
	public GameObject bulletPrefab;
	public bool canAttack;
	public float speed;
	public Transform weaponParent;
	public Transform shieldParent;
	public Transform previewItemParent;
	public AudioSource[] attackAudio;

	private Vector3 movementDirection;
	private Vector3 facingDirection;
	private Rigidbody2D rigidBody;
	private bool isFrozen;
	private bool isDirectionFrozen;
	private bool isAttacking;
	private ItemType pickedUpItem = ItemType.None;
	private ItemType equippedWeapon = ItemType.None;
	private ItemType equippedShield = ItemType.None;
	private GameObject pickupItem;
	private Vector2 pushDirection;
	private Vector2 recievedDirection;
	private float pushTime;
	private float lastFreezeTime;
	private int lastSetDirectionFrameCount;

	void Awake() {
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void Start() {
		// SetDirection(new Vector2(0, -1));
	}

	void Update() {
		UpdatePushTime();
		UpdateDirection();
		ResetRecievedDirection();
	}

	void FixedUpdate() {
		UpdateMovement();
	}	

	void UpdatePushTime() {
		pushTime = Mathf.MoveTowards(pushTime, 0, Time.deltaTime);
	}

	void ResetRecievedDirection() {
		recievedDirection = Vector2.zero;
	}

	void UpdateDirection() {
		if(isFrozen) {
			if(recievedDirection != Vector2.zero &&
				GetItemPickedUp() != ItemType.None &&
				GetTimeSinceFrozen() > 0.5f) {
				pickedUpItem = ItemType.None;
				SetFrozen(false, false);
				for(int i = 0; i < previewItemParent.childCount; i++) {
					Destroy(previewItemParent.GetChild(i).gameObject);
				}
			}
		}

		if(isDirectionFrozen && recievedDirection != Vector2.zero) {
			return;
		}

		if(isAttacking) {
			return;
		}

		if(IsBeingPushed()) {
			movementDirection = pushDirection;
			return;
		}

		if(Time.frameCount == lastSetDirectionFrameCount) {
			return;
		}
		movementDirection = new Vector3(recievedDirection.x, recievedDirection.y, 0);
		if(recievedDirection != Vector2.zero) {
			Vector3 facingDirection = movementDirection;
			if(facingDirection.x != 0 && facingDirection.y != 0) {
				 if( facingDirection.x == this.facingDirection.x )
                {
                    facingDirection.y = 0;
                }
                else if( facingDirection.y == this.facingDirection.y )
                {
                    facingDirection.x = 0;
                }
                else
                {
                    facingDirection.x = 0;
                }
			}
			
			this.facingDirection = facingDirection;
			lastSetDirectionFrameCount = Time.frameCount;
		}
	}

	float GetTimeSinceFrozen() {
		if(!IsFrozen()) {
			return 0f;
		}
		return Time.realtimeSinceStartup - lastFreezeTime;
	}

	void UpdateMovement() {
		if(FadeManager.instance != null) {
			if(FadeManager.instance.IsFading()) {
				rigidBody.velocity = Vector2.zero;
				return;
			}
		}
		if(isFrozen || isAttacking) {
			rigidBody.velocity = Vector2.zero;
			return;
		}
		if(movementDirection != Vector3.zero) {
			movementDirection.Normalize();
		}
		if(IsBeingPushed()) {
			rigidBody.velocity = pushDirection;
		} else {
			rigidBody.velocity = movementDirection * speed;
		}
	}

	new public void SetDirection(Vector2 direction) {
		if(direction == Vector2.zero) {
			return;
		}
		recievedDirection = direction;
		// if(isAttacking) {
		// 	return;
		// }
		// if(healthModel != null && healthModel.GetHealth() <= 0) { 
		// 	return;
		// }
		// if(direction != Vector2.zero &&
		// 	GetItemPickedUp() != ItemType.None) {
		// 	pickedUpItem = ItemType.None;
		// 	SetFrozen(false);
		// 	Destroy(pickupItem);
		// }
		// if(isFrozen) {
		// 	return;
		// }
		// if(IsBeingPushed()) {
		// 	movementDirection = -pushDirection;
		// 	return;
		// }
		// movementDirection = new Vector3(direction.x, direction.y, 0);
		// if(direction != Vector2.zero) {
		// 	facingDirection = movementDirection;
		// }
	}

	GameObject EquipItem(ItemType itemType, ItemData.EquipPosition equipPosition, 
		Transform equipParent, ref ItemType equippedItemSlot) {
		
		if(equipParent == null) {
			return null;
		}
		ItemData itemData = Database.item.FindItem(itemType);
		if(itemData == null) {
			return null;
		}
		if(itemData.isEquipable != equipPosition) {
			return null;
		}
		equippedWeapon = itemType;
		GameObject newItemObject = (GameObject)Instantiate(itemData.prefab);
		newItemObject.transform.parent = equipParent;
		newItemObject.transform.localPosition = Vector2.zero;
		newItemObject.transform.localRotation = Quaternion.identity;

		return newItemObject;
	}

	public void EquipShield(ItemType itemType) {
		GameObject newShieldObject = EquipItem(itemType, ItemData.EquipPosition.ShieldHand, shieldParent, ref equippedShield);
		if (newShieldObject == null)
		{
			return;
		}
	}		

	public void EquipWeapon(ItemType itemType) {
		EquipItem(itemType, ItemData.EquipPosition.SwordHand, weaponParent, ref equippedWeapon);
	}

	public void ShowItemPickup(ItemType itemType) {
		if(previewItemParent == null) {
			return;
		}
		ItemData itemData = Database.item.FindItem(itemType);
		if(itemData == null) {
			return;
		}
		pickupItem = (GameObject)Instantiate(itemData.prefab);
		pickupItem.transform.parent = previewItemParent;
		pickupItem.transform.localPosition = Vector2.zero;
		pickupItem.transform.localRotation = Quaternion.identity;
		
		isFrozen = true;
		pickedUpItem = itemType;
	}

	public void PushCharacter(Vector2 pushDirection, float time) {
		if(isAttacking) {
			GetComponentInChildren<CharacterAnimationListener>().OnAttackFinished();
		}
		this.pushDirection = pushDirection;
		this.pushTime = time;
	}

	public ItemType GetItemPickedUp() {
		return pickedUpItem;
	}

	public bool CanAttack() {
		if(isAttacking) {
			return false;
		}
		if(isFrozen) {
			return false;
		}
		if(IsBeingPushed()) {
			return false;
		}
		if(equippedWeapon == ItemType.None) {
			return false;
		}
		return true;
	}

	public void DoShoot() {
		if(bulletPrefab != null) {
			GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
			bullet.GetComponent<Rigidbody2D>().velocity = GetFacingDirection() * 10;
			Destroy(bullet, 3f);
		}
	}

	public void DoAttack() {
		int audioRandom = Random.Range(0, attackAudio.Length);

		attackAudio[audioRandom].Play();
		Debug.Log(audioRandom);
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

	public bool IsFrozen() {
		return isFrozen;
	}

	public bool IsBeingPushed() {
		return pushTime > 0;
	}

	public void SetFrozen(bool isFrozen, bool isDirectionFrozen) {
		this.isFrozen = isFrozen;
		this.isDirectionFrozen = isDirectionFrozen;
		if(isFrozen) {
			lastFreezeTime = Time.realtimeSinceStartup;
		}
	}

	public void OnAttackStarted() {
		isAttacking = true;
	}

	public void OnAttackFinished() {
		isAttacking = false;
	}

}
