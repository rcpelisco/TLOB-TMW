using System;
using System.Collections;
using UnityEngine;

public class StatTest : MonoBehaviour {

	private StatCollection stats;

	void Start () {
		stats = new DefaultStat();

		var statTypes = Enum.GetValues(typeof(StatType));
		foreach(var statType in statTypes) {
			Stat stat = stats.GetStat((StatType)statType);
			if(stat != null) {
				Debug.Log(string.Format("Stat {0}'s value is {1}", stat.statName, stat.statValue));
			}
		}
	}
}
