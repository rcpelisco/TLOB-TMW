﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database {
	private static ItemDatabase itemDatabase;
	public static ItemDatabase item {
		get {
			if(itemDatabase == null) {
				itemDatabase = Resources.Load<ItemDatabase>("Databases/ItemDatabase");
			}
			return itemDatabase;
		}
	}
}
