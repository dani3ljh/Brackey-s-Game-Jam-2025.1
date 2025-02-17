using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// Makes the camera follow the player aka the better ciniminchin 
/// </summary>

public class FollowPlayer : MonoBehaviour
{
    [Header("Data")]
    public float SPEED;
    public Vector3 velocity = Vector3.zero;
    public float minX = -10;
    public float minY = -13;
    public float maxY = 13;
    public float lerpdura = 3;
    private float time;
    private float newX;
    private float newminY;
    private float newmaxY;
    private float yCamDis = 5;
    private float xCamDis = 10;

    [Header("GameObjects")]
    public GameObject player;

    /// <summary>
    /// /// Start is called on the frame when a script is enabled just before any of the Update methods are called.
    /// </summary>
    void Start()
    {
        Vector3 camPos = transform.position;
        Vector3 plaPos = player.transform.position;
        Vector3 newCam = new Vector3(plaPos.x, plaPos.y, camPos.z);
        transform.position = newCam;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        newX = minX + xCamDis;
        newminY = minY + yCamDis;
        newmaxY = maxY - yCamDis;
        Vector3 camPos = transform.position;
        Vector3 plaPos = player.transform.position;
        Vector3 newCam = new Vector3(camPos.x, camPos.y, camPos.z);
        if (plaPos.x >= newX ){
            newCam.x = Mathf.Lerp(camPos.x, plaPos.x,time /lerpdura);
        }
        if (plaPos.y >= newminY && plaPos.y <= newmaxY){
            newCam.y = Mathf.Lerp(camPos.y, plaPos.y, time / lerpdura);
        }
        time += Time.deltaTime;
        transform.position = Vector3.SmoothDamp(camPos, newCam, ref velocity, SPEED);
    }
}
