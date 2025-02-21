using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uicontroller : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Data")]
    public float minValue;
    public float maxValue;



    [Header("Game Objects")]
    public Text MeterCounter;
    public GameObject boulder;
    public Slider ProgressBar;


    void Start()
    {
        ProgressBar.maxValue = maxValue;
        ProgressBar.minValue = minValue;
    }

    // Update is called once per frame
    void Update()
    {
        MeterCounter.text = Mathf.Round(boulder.transform.position.x).ToString() + "M";
        ProgressBar.value = boulder.transform.position.x;
    }
}
