using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat {

	public List<StatBonus> baseModifier { get; set; } 
	public int baseValue { get; set; }
	public string statName { get; set; }
	public string statDescription { get; set; }
	public int finalValue { get; set; }

	public BaseStat(int baseValue, string statName, string statDescription) {
		 this.baseModifier = new List<StatBonus>();
		 this.baseValue = baseValue;
		 this.statName = statName;
		 this.statDescription = statDescription;
	}

	public void AddStatBonus(StatBonus statBonus) {
		this.baseModifier.Add(statBonus);
	}

	public void RemoveStatBonus(StatBonus statBonus) {
		this.baseModifier.Remove(statBonus);
	}

	public int GetCalculatedStatValue() {
		this.finalValue = 0;
		this.baseModifier.ForEach(x => this.finalValue += x.bonusValue);
		finalValue += baseValue;
		return finalValue;
	}
}
