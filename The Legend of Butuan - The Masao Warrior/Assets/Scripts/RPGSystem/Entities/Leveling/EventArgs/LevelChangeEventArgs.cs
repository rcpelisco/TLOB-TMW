using System.Collections;
using System;
using UnityEngine;

public class LevelChangeEventArgs : EventArgs {
	public int newLevel { get; private set; }
	public int oldLevel { get; private set; }

	public LevelChangeEventArgs(int newLevel, int oldLevel) {
		this.newLevel = newLevel;
		this.oldLevel = oldLevel;
	}
}
