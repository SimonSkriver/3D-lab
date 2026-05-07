using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class GameState
{
    public int Lives;
    public int Level;
    public string CharacterName;
    public List<string> ItemsCarried;
 
    public const string PlayerPrefsKeyName = "SavedGameState";

    public void SaveToPlayerPrefs()
    {
        string json = JsonUtility.ToJson(this);

        PlayerPrefs.SetString(PlayerPrefsKeyName, json);
        PlayerPrefs.Save();
    }

    public static GameState CreateFromPlayerPrefs()
    {
        if(!PlayerPrefs.HasKey(PlayerPrefsKeyName))
        {
            return null;
        }

        string json = PlayerPrefs.GetString(PlayerPrefsKeyName);

        return JsonUtility.FromJson<GameState>(json);           
    }
}