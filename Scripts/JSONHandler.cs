using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONHandler : MonoBehaviour
{
    PlayerData playerData = new PlayerData();

    private string jsonFile;

    private void Awake()
    {
        jsonFile = Application.persistentDataPath + "/GameData.json";
    }

    public void PlayerName(string name)
    {
        playerData.name = name;
    }

    public void PlayerScore(int score)
    {
        playerData.score = score;
    }

    public void SaveData()
    {
        WriteFile(playerData);
    }

    public void WriteFile(PlayerData player)
    {
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }


        if (!File.Exists(jsonFile))
        {
            List<PlayerData> list = new List<PlayerData>();
            list.Add(player);

            string jsonContent = JsonUtility.ToJson(list);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(jsonFile))
            {
                file.WriteLine(jsonContent);
            }
        }
        else
        {
            string fileContent = File.ReadAllText(jsonFile);
            
            PlayerDataList list = new PlayerDataList();

            list = JsonUtility.FromJson<PlayerDataList>(fileContent);
            list.data.Add(player);

            PlayerDataList listOfData = new PlayerDataList();
            listOfData.data = list.data;

            string jsonContent = JsonUtility.ToJson(listOfData);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(jsonFile))
            {
                file.WriteLine(jsonContent);
            }
        }
    }

    public List<PlayerData> ReadFile()
    {
        if (File.Exists(jsonFile))
        {
            string jsonContent = File.ReadAllText(jsonFile);

            PlayerDataList list = new PlayerDataList();
            list = JsonUtility.FromJson<PlayerDataList>(jsonContent);

            return list.data;
        }

        return null;
    }
}
