using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Follow the player's x
/// </summary>
public class FollowPlayerX : MonoBehaviour
{
    [Header("Game Objects")]
    public Transform player;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        Vector3 startPos = transform.position;
        Vector3 playerPos = player.position;
        transform.position = new Vector3(playerPos.x, startPos.y, startPos.z);
    }
}
