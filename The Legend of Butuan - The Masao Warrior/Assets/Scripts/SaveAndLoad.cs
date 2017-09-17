using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour {

	public List<int> list1 = new List<int>();
	private savedata data;
	public Vector3 xyz = new Vector3();

	void Start() {
		Load();
	}

	void Update () {
		if(Input.GetKeyDown (KeyCode.Q))
			Save();
	}

	public void Save () {
		if(!Directory.Exists(Application.dataPath + "/saves"))
			Directory.CreateDirectory(Application.dataPath + "saves");
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.dataPath + "/saves/SaveData.dat");
		CopySaveData();
		bf.Serialize(file, data);
		file.Close();
	}

	public void CopySaveData ()
	{
		data.list1.Clear();
		
		foreach (var i in list1)
		{
			data.list1.Add(i);
		}
		data.position = Vector3ToSerVector3(xyz);
	}

	public void Load()
	{
		if(File.Exists(Application.dataPath + "/saves/SaveData.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.dataPath + "/saves/SaveData.dat", FileMode.Open);
			data = (savedata)bf.Deserialize(file);

			CopyLoadData();
			file.Close();
		}
	}

	public void CopyLoadData()		
	{
		list1.Clear();
		foreach(int i in data.list1)
		{
			list1.Add(i);
		}

		data.position = Vector3ToSerVector3(xyz);

	} 
	public static SerVector3 Vector3ToSerVector3(Vector3 v3) 
	{
		SerVector3 sv3 = new SerVector3();
		sv3.x = v3.x;
		sv3.y = v3.y;
		sv3.z = v3.z;		

		return sv3;

	}


	public static Vector3 SerVector3ToVector (SerVector3 sv3)
	{
		Vector3 v3 = new Vector3();
		v3.x = sv3.x;
		v3.y = sv3.y;
		v3.z = sv3.z;

		return v3;
		
	}

}

[System.Serializable]
public class savedata
{
	public SerVector3 position;
	public List<int> list1 = new List<int>();
}

[System.Serializable]
public class SerVector3
{
	public float x;
	public float y;
	public float z;
	
}