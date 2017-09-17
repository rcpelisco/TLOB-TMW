using System.Collections;
using UnityEngine;

public class StatBonus {

	public int bonusValue { get; set; }

	public StatBonus(int bonusValue) {
		this.bonusValue = bonusValue; 
		Debug.Log("Bonus Stat!");
	}
}
