using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonSaveManager : MonoBehaviour
{
    [System.Serializable]
    public class SceneData
    {
        public string name;
        public int age;
    }

    private string filePath;

    private void Awake()
    {
        //für echte Build persistantDataPath nutzen !!! 
        filePath = Application.dataPath + "/SceneData.json";
    }

    public void SaveData()
    {
        SceneData data = new SceneData
        {
            name = "Oliver Martin",
            age = 18
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
        print("Data saved");
    }

    public void LoadData()
    {
        if(File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SceneData data = JsonUtility.FromJson<SceneData>(json);
            print($"Data loaded: Name - {data.name}, Age - {data.age}");
        }
        else
        {
            Debug.LogError("Save file not found");
        }
    }

}
