using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    public Flower flower;

    void Start()
    {
    }

    public void SetName()
    {
        InputField name = GetComponent<InputField>();
        flower.FlowerName = name.text;
        gameObject.SetActive(false);
    }
}
