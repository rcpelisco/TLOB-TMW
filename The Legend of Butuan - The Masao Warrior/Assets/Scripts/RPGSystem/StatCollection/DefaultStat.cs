using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultStat : StatCollection {
	protected override void ConfigureStats() {
		var health = CreateOrGetStat<Stat>(StatType.Health);
		health.statName = "Health";
		health.statBaseValue = 100;
	}
}
