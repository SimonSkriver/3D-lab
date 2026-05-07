using UnityEngine;

public class SaveAndLoadButton : MonoBehaviour
{
    SaveData myData = new SaveData();
    [SerializeField] GameObject player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    public void Save()
    {
        myData.playerPosition = player.transform.position;
        SaveGameSystem.Save(myData);
        Debug.Log("Game saved");
    }

    public void Load()
    {
        Debug.Log("Loading game");
        SaveGameSystem.Load(myData);
        player.transform.position = myData.playerPosition;
    }
}
