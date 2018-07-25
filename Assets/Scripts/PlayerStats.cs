using UnityEngine;
using System.Collections;
// to write to file
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerStats : MonoBehaviour {

    public static PlayerStats instance;

    public PlayerData data;

    string filename = "/playerStats.dat";

	void Awake () 
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject); // persist the data between scenes
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
	}


    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + filename);
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + filename))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + filename, FileMode.Open);
            data = (PlayerData)bf.Deserialize(file);
            file.Close();
        }
    }

    [Serializable]
    public class PlayerData
    {
        public int loinsCollected;
    }
}
