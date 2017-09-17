using System.Collections;
using UnityEngine;
using System;

public abstract class EntityLevel : MonoBehaviour {
	[SerializeField]
	private int _level = 0;

	[SerializeField]
	private int _levelMin = 0;

	[SerializeField]
	private int _levelMax = 100;

	private int _expCurrent = 0;
	private int _expRequire = 0;

	public event EventHandler<ExpGainEventArgs> OnExpGain;
	public event EventHandler<LevelChangeEventArgs> OnLevelChange;
	public event EventHandler<LevelChangeEventArgs> OnLevelUp;
	public event EventHandler<LevelChangeEventArgs> OnLevelDown;

	public int level {
		get { return _level; }
		set { _level = value; }
	}

	public int levelMin {
		get { return _levelMin; }
		set { _levelMin = value; }
	}

	public int levelMax {
		get { return _levelMax; }
		set { _levelMax = value; }
	}

	public int expCurrent { 
		get { return _expCurrent; } 
		set { _expCurrent = value; } 
	}

	public int expRequire { 
		get { return _expRequire; } 
		set { _expRequire = value; } 
	}

	public abstract int GetRequiredExpForLevel(int level);

	void Awake() {
		expRequire = GetRequiredExpForLevel(level);
	}

	public void ModifyExp(int amount) {
		expCurrent += amount;
		if(OnExpGain != null) {
			OnExpGain(this, new ExpGainEventArgs(amount));
		}
		CheckCurrentExp();
	}

	public void SetCurrentExp(int value) {
		int expGained = value - expCurrent;
		expCurrent = value;
		if(OnExpGain != null) {
			OnExpGain(this, new ExpGainEventArgs(expGained));
		}
		CheckCurrentExp();
	}

	public void CheckCurrentExp() {
		InternalCheckCurrentExp();
	}

	private void InternalCheckCurrentExp() {
		while(true) {
			if(expCurrent > expRequire) {
				expCurrent -= expRequire;
				InternalIncreaseCurrentLevel();
			} else if(expCurrent < 0) {
				expCurrent += GetRequiredExpForLevel(level - 1);
				InternalDecreaseCurrentLevel();
			} else {
				break;
			}
		}
	}

	public void IncreaseCurrentLevel() {
		int oldLevel = level;
		InternalIncreaseCurrentLevel();
		if(oldLevel != level && OnLevelChange != null) {
			OnLevelChange(this, new LevelChangeEventArgs(level, oldLevel));
		}
	}

	private void InternalIncreaseCurrentLevel() {
		int oldLevel = level++;
		if(level > levelMax) {
			level = levelMax;
			expCurrent = GetRequiredExpForLevel(level);
		}
		expRequire = GetRequiredExpForLevel(level);
		if(OnLevelUp != null) {
			OnLevelUp(this, new LevelChangeEventArgs(level, oldLevel));
		}
	}

	public void DecreaseCurrentLevel() {
		int oldLevel = level;
		InternalDecreaseCurrentLevel();
		if(oldLevel != level && OnLevelChange != null) {
			OnLevelChange(this, new LevelChangeEventArgs(level, oldLevel));
		}
	}

	private void InternalDecreaseCurrentLevel() {
		int oldLevel = level--;
		if(level < levelMin) {
			level = levelMin;
			expCurrent = 0;
		}
		expRequire = GetRequiredExpForLevel(level);
		if(OnLevelDown != null) {
			OnLevelDown(this, new LevelChangeEventArgs(level, oldLevel));
		}
	}
	
	public void SetLevel(int targetLevel) {
		SetLevel(targetLevel, true);
	}

	public void SetLevel(int level, bool clearExp) {
		int oldLevel = level;
		this.level = level;
		expRequire = GetRequiredExpForLevel(level);

		if(clearExp) {
			SetCurrentExp(0);
		}else {
			InternalCheckCurrentExp();
		}

		if(oldLevel != level && OnLevelChange != null) {
			OnLevelChange(this, new LevelChangeEventArgs(level, oldLevel));
		}
	}
}

