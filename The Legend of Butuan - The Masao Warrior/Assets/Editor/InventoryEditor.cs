using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InventoryUI))]
public class InventoryEditor : Editor {

	private SerializedProperty itemImagesProperty;
	private SerializedProperty itemsProperty;
	private bool[] showItemSlots = new bool[InventoryUI.numItemSlots];
	private const string inventoryPropItemImagesName = "itemImages";
	private const string inventoryPropItemsName = "items";

	void OnEnable() {
		itemImagesProperty = serializedObject.FindProperty(inventoryPropItemImagesName);
		itemsProperty = serializedObject.FindProperty(inventoryPropItemsName);
	}

	public override void OnInspectorGUI() {
		serializedObject.Update();
		for (int i = 0; i < InventoryUI.numItemSlots; i++) {
			ItemSlotGUI(i);
		}
		serializedObject.ApplyModifiedProperties();
	}

	void ItemSlotGUI(int index) {
		EditorGUILayout.BeginVertical(GUI.skin.box);
		EditorGUI.indentLevel++;
		showItemSlots[index] = EditorGUILayout.Foldout(showItemSlots[index], "Item slot " + index);
		if(showItemSlots[index]) {
			EditorGUILayout.PropertyField(itemImagesProperty.GetArrayElementAtIndex(index));
			EditorGUILayout.PropertyField(itemsProperty.GetArrayElementAtIndex(index));
		}
		EditorGUI.indentLevel--;
		EditorGUILayout.EndVertical();
	}
}
