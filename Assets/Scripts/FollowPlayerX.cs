using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;



/// <summary>
/// makes the walls follow the player
/// </summary>
public class FollowPlayerX : MonoBehaviour
{
    [Header("Data")]
    [Header("Game Objects")]
    public GameObject player;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        Vector3 orgPos = transform.position;
        Vector3 plaPos = player.transform.position;
        transform.position = new Vector3(plaPos.x, orgPos.y, orgPos.z);
    }
}
