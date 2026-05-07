using UnityEngine;

public class Health : MonoBehaviour
{
    private SaveData myData;

    void Start()
    {
        //myData.playerHealth = 50f;
        Debug.Log(Application.persistentDataPath);
    }
}
