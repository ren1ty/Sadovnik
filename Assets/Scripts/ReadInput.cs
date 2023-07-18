using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    public Flower flower;
    public List<SeFlower> flowers = new List<SeFlower>();

    private const string saveKey = "fl";

    void Start()
    {

    }

    public void SetName()
    {
        InputField name = GetComponent<InputField>();
        flower.FlowerName = name.text;
        flowers.Add(new SeFlower(flower.FlowerName));//adding new flower to the list
        SaveManager.Save(saveKey, flowers);
        gameObject.SetActive(false);
    }

    private void Save()
    {
        //SaveManager.Save(saveKey, flowers);
    }
}
