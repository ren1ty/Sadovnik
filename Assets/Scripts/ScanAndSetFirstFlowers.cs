using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ScanAndSetFirstFlowers : MonoBehaviour
{
    [SerializeField] private GameObject PlaneMarkerPrefab;
    [SerializeField] private GameObject ObjectToSpawn;

    [SerializeField] private int StartFlowersCount = 1;
    private int FlowersCount = 0;

    [SerializeField] private GameObject readInput;

    private ARRaycastManager ARRaycastManagerScript;
    

    private Vector2 TouchPosition;

    void Start()
    {
        ARRaycastManagerScript = FindObjectOfType<ARRaycastManager>();

        PlaneMarkerPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (FlowersCount < StartFlowersCount)
        {
            ShowMarkerAndSetFlowers();
        }
    }

    void ShowMarkerAndSetFlowers()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        ARRaycastManagerScript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            PlaneMarkerPrefab.transform.position = hits[0].pose.position;
            PlaneMarkerPrefab.SetActive(true);
        }
       
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            GameObject spawnFlower = Instantiate(ObjectToSpawn, hits[0].pose.position, ObjectToSpawn.transform.rotation);
            FlowersCount++;
            readInput.SetActive(true);
            readInput.GetComponent<ReadInput>().flower = spawnFlower.GetComponent<Flower>();
            PlaneMarkerPrefab.SetActive(false);
        }
    }
}
