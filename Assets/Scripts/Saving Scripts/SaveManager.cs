using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    public static void Save(string key, List<SeFlower> flowers)
    {
        UnityEngine.Debug.Log(flowers[0]);
        // string jsonDataString = JsonUtility.ToJson(flowers, true);
        string jsonDataString = JsonConvert.SerializeObject(flowers, Formatting.Indented);
         UnityEngine.Debug.Log(jsonDataString);
        PlayerPrefs.SetString(key, jsonDataString);
    }

    public static List<SeFlower> Load(string key) //where T : new()
    {
        if (PlayerPrefs.HasKey(key))
        {
            string loadedString = PlayerPrefs.GetString(key);
            UnityEngine.Debug.Log(loadedString);
            UnityEngine.Debug.Log("Im working");
            return JsonConvert.DeserializeObject<List<SeFlower>>(loadedString);
        }
        else
        {
            UnityEngine.Debug.Log("Im here");
            return new List<SeFlower>();
        }
    }
}
