using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat {
	private string _statName;
	private int _statBaseValue;

	public string statName {
		get { return _statName; }
		set { _statName = value; }
	}

	public virtual int statValue {
		get { return _statBaseValue; }
	}

	public int statBaseValue {
		get { return _statBaseValue; }
		set { _statBaseValue = value; }
	}

	public Stat() {
		this.statName = string.Empty;
		this.statBaseValue = 0;
	}

	public Stat(string name, int value) {
		this.statName = name;
		this.statBaseValue = value;
	}
}
