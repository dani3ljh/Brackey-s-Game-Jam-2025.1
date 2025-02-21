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
    public float offsetY;
    public float camSizeX;
    public float camSizeY;




    [Header("Game Objects")]
    public Text MeterCounter;
    public GameObject boulder;
    public Slider ProgressBar;
    public GameObject arrow;
    public GameObject player;
    public GameObject cam;


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
        Vector2 newArrowpos = new (player.transform.position.x, player.transform.position.y + offsetY);
        arrow.transform.position = newArrowpos;
        Vector3 offset = boulder.transform.position - arrow.transform.position;
        arrow.transform.rotation = Quaternion.LookRotation(Vector3.forward, offset);

        if (boulder.transform.position.x > cam.transform.position.x + camSizeX || boulder.transform.position.x < cam.transform.position.x - camSizeX || boulder.transform.position.y > cam.transform.position.y + camSizeY || boulder.transform.position.y < cam.transform.position.y - camSizeY)
        {
            arrow.SetActive(true);
        }
        else 
        {
            arrow.SetActive(false);
        }


    }
}
