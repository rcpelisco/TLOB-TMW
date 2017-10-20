using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationListener : MonoBehaviour {

	public CharacterMovementModel movementModel;
	public CharacterMovementView movementView;

	public void OnAttackStarted(int sortingOrder) {
		if(movementModel != null) {
			movementModel.OnAttackStarted();
		}
		ShowWeapon();
		SetWeaponSortingOrder(sortingOrder);
	}

	public void OnAttackFinished() {
		if(movementModel != null) {
			movementModel.OnAttackFinished();
		}
		HideWeapon();
	}

	public void ShowWeapon() {
		if(movementView != null) {
			movementView.ShowWeapon();
		}
	}

	public void HideWeapon() {
		if(movementView != null) {
			movementView.HideWeapon();
		}
	}

	public void ShowShield() {
		if(movementView != null) {
			movementView.ShowShield();
		}
	}

	public void HideShield() {
		if(movementView != null) {
			movementView.HideShield();
		}
	}

	public void SetWeaponSortingOrder(int sortingOrder) {
		if(movementView != null) {
			movementView.SetWeaponSortingOrder(sortingOrder);
		}
	}
}
