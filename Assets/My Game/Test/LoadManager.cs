using System.IO;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("UpdateJson", 2f);
    }

    // Update is called once per frame
    void UpdateJson()
    {
        string path = Application.persistentDataPath + "/playerdata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Player Name: " + data.playerName);
            Debug.Log("Level: " + data.level);
            Debug.Log("HP: " + data.hp);
        }
    }
}
