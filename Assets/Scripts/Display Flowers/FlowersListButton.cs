using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FlowersListButton : MonoBehaviour
{
    [SerializeField] GameObject ScrollView;
    [SerializeField] Sprite crossButton;
    [SerializeField] Sprite hamButton;
    private Button button;

    //test
    public List<Flower> flowers = new List<Flower>();

    private const string saveKey = "saveFckngFlowers";

    int clickCount = 0;

    ScrollViewAdaptor scrollViewAdaptorScript;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OpenList);

        ScrollView.transform.localScale = Vector2.zero;

        scrollViewAdaptorScript = GetComponent<ScrollViewAdaptor>();
    }

    public void OpenList()
    {
        if (clickCount % 2 == 0)
        {
            ScrollView.transform.LeanScale(Vector2.one, 0.8f);
            button.image.sprite = crossButton;
        }
        else
        {
            ScrollView.transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
            button.image.sprite = hamButton;
        }
        clickCount++;

    }
}
