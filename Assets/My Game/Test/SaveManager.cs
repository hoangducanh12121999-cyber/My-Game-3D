using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string path = Application.persistentDataPath + "/playerdata.json";

        PlayerData data = new PlayerData();
        data.playerName = "John Doe";
        data.level = 1;
        data.hp = 100f;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int level;
    public float hp;
}
