using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCollection {
	private Dictionary<StatType, Stat> _statDictionary;

	public StatCollection() {
		_statDictionary = new Dictionary<StatType, Stat>();
		ConfigureStats();
	} 

	protected virtual void ConfigureStats() {

	}

	public bool Contains(StatType statType) {
		if(_statDictionary.ContainsKey(statType)) {
			return true;
		}
		return false;
	}

	public Stat GetStat(StatType statType) {
		if(Contains(statType)) {
			return _statDictionary[statType];
		}
		return null;
	}

	public T GetStat<T>(StatType statType) where T : Stat {
		return GetStat(statType) as T;
	}

	public T CreateStat<T>(StatType statType) where T : Stat {
		T stat = System.Activator.CreateInstance<T>();
		_statDictionary.Add(statType, stat);
		return stat;
	}

	protected T CreateOrGetStat<T>(StatType statType) where T : Stat{
		T stat = GetStat<T>(statType);
		if(stat == null) {
			 stat = CreateStat<T>(statType);
		} 
		return stat;
	}
}
