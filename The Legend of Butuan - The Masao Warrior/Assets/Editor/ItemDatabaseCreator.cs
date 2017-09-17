using System.Collections;
using UnityEditor;
using UnityEngine;

public class ItemDatabaseCreator : MonoBehaviour {

	[MenuItem("RC /Databases/Create Item Database")]
	public static void CreateItemDatabase() {
		ItemDatabase newDatabase = ScriptableObject.CreateInstance<ItemDatabase>();
		AssetDatabase.CreateAsset(newDatabase, "Assets/ItemDatabase.asset");
		AssetDatabase.Refresh();
	}
}
