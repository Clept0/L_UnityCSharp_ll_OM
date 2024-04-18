using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONColorSave : MonoBehaviour
{
    [System.Serializable]
    public class SceneDataColor
    {
        public string colorString;
    }

    private string filePath;
    private GameObject sphere;

    private void Awake()
    {
        //für echte Build persistantDataPath nutzen !!! 
        filePath = Application.dataPath + "/SceneDataColor.json";
        sphere = GameObject.Find("Sphere");

    }

    private void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        SceneDataColor data = new SceneDataColor();
        data.colorString = ColorUtility.ToHtmlStringRGBA(sphere.GetComponent<MeshRenderer>().material.color);

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
        print("Data saved");
    }

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SceneDataColor data = JsonUtility.FromJson<SceneDataColor>(json);

            if(ColorUtility.TryParseHtmlString("#" + data.colorString, out Color color))
            {
                sphere.GetComponent<MeshRenderer>().material.color = color;
                print($"Data loaded: Color - #{data.colorString}");
            }
       
        }
        else
        {
            Debug.LogError("Save file not found");
        }
    }

    public void ChangerColor()
    {
        sphere.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }

}
