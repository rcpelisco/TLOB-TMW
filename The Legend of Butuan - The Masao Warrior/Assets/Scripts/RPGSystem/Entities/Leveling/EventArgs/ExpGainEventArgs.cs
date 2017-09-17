using System.Collections;
using System;
using UnityEngine;

public class ExpGainEventArgs : EventArgs {

	public int expGained { get; private set; }
	public ExpGainEventArgs(int expGained) {
		this.expGained = expGained;
	}
}
