using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONColorSave_XOR : MonoBehaviour
{
    [System.Serializable]
    public class SceneDataColor_XOR
    {
        public string colorString;
    }

    private string filePath;
    private GameObject sphere;

    //Key for encryption
    [SerializeField] private string encryptionKey = "einfacherSchlüssel"; 

    private void Awake()
    {
        //für echte Build persistantDataPath nutzen !!! 
        filePath = Application.dataPath + "/SceneDataColor_XOR.json";
        sphere = GameObject.Find("Sphere");

    }

    private void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        SceneDataColor_XOR data = new SceneDataColor_XOR();
        data.colorString = ColorUtility.ToHtmlStringRGBA(sphere.GetComponent<MeshRenderer>().material.color);

        string json = JsonUtility.ToJson(data, true);

        //encryption
        string encryptedJson = EncryptDecrypt(json);

        File.WriteAllText(filePath, encryptedJson);
        print("Data saved");
    }

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            //verschlüsselte json laden
            string encryptedJson = File.ReadAllText(filePath);

            //entschlüsseln
            string json = EncryptDecrypt(encryptedJson);

            SceneDataColor_XOR data = JsonUtility.FromJson<SceneDataColor_XOR>(json);

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

    //XOR EncryptDecrypt
    private string EncryptDecrypt(string text)
    {
        char[] chars = text.ToCharArray();
        for(int i = 0; i < chars.Length; i++)
        {
            chars[i] ^= encryptionKey[i % encryptionKey.Length];
        }
        return new string(chars);
    }

}
