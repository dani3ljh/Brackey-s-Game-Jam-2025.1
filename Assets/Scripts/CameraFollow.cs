using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Makes the camera follow the player aka the better ciniminchin 
/// </summary>

public class CameraFollow : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private float speed;
    [SerializeField] private float minX = -10;
    [SerializeField] private float minY = -13;
    [SerializeField] private float maxY = 13;
    private Vector2 screenSize;
    private float time;

    [Header("GameObjects")]
    [SerializeField] private Transform player;
    private Camera _camera;

    /// <summary>
    /// /// Start is called on the frame when a script is enabled just before any of the Update methods are called.
    /// </summary>
    void Start() {
        _camera = Camera.main;
        Vector2 cameraScreenSize = new(Screen.width, Screen.height);
        screenSize = _camera.ScreenToWorldPoint(cameraScreenSize);
        time = 0;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        Vector3 newPos = new(player.position.x, player.position.y, transform.position.z);

        if (newPos.x < minX + screenSize.x) {
            newPos.x = minX + screenSize.x;
        }
        if (newPos.y < minY + screenSize.y) {
            newPos.y = minY + screenSize.y;
        }
        if (newPos.y > maxY - screenSize.y) {
            newPos.y = maxY - screenSize.y;
        }

        transform.position = Vector3.Lerp(transform.position, newPos, time / speed);

        time += Time.deltaTime;
    }
}
