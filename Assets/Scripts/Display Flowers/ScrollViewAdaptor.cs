using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewAdaptor : MonoBehaviour
{
    public RectTransform prefab;
    public RectTransform content;
    public List<SeFlower> flowers = new List<SeFlower>();

    private const string saveKey = "fl";

    public void Start()
    {
        flowers = SaveManager.Load(saveKey);
    }
    
    public void UpdateItems()
    {
        flowers = SaveManager.Load(saveKey);
       

        if (flowers != null)
        {
            int itemsCount = flowers.Count;
            if (itemsCount > 0)
            {
                List<ItemModel> items = CreatingItems(itemsCount);
                OnRecievedModels(items);
            }
        }
    }

    void OnRecievedModels(List<ItemModel> models)
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach(var model in models)
        {
            var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(transform, false);
            InitializeItemView(instance, model);
        }
    }

    void InitializeItemView(GameObject viewGameObject, ItemModel model)
    {
        ItemView view = new ItemView(viewGameObject.transform);
        view.txtName.text = model.Name;
    }

    public List<ItemModel> CreatingItems(int count)
    {
        List<ItemModel> results = new List<ItemModel>();
        List<string> names = new List<string>();

        for (int i = 0; i < count; i++)
        {
            results.Add(new ItemModel(flowers[i].Name));
        }
        return results;
    }

    public class ItemModel
    {
        public string Name;

        public ItemModel(string Name)
        {
            this.Name = Name;
        }
    }

    public class ItemView
    {
        public Text txtName;

        public ItemView(Transform rootView)
        {
            txtName = rootView.Find("NameField").GetComponent<Text>();
        }
    }



   private void Load()
    {
        flowers = SaveManager.Load(saveKey);
    }

}
