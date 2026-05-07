using System.IO;
using UnityEngine;

public static class SaveGameSystem
{
    public static void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savegame", json);
    }

    public static void Load(SaveData data)
    {
        if (File.Exists(Application.persistentDataPath))
        {
            //Read json string from file
            string json = File.ReadAllText(Application.persistentDataPath);

            //Restore from json string to GameData
            data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log(data.playerHealth);
        }
        else
        {
            Debug.LogWarning("Save file not found. Making new");
            data = new SaveData();
        }
    }
}