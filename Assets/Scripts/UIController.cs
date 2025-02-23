using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles UI
/// </summary>
public class UIController : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;
    [SerializeField] private float offsetY;
    [SerializeField] private float camSizeX;
    [SerializeField] private float camSizeY;

    [Header("Game Objects")]
    [SerializeField] private Text meterCounter;
    [SerializeField] private Transform boulder;
    [SerializeField] private Slider progressBar;
    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform player;
    [SerializeField] private Transform cam;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods are called.
    /// </summary>
    void Start() {
        progressBar.maxValue = maxValue;
        progressBar.minValue = minValue;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        progressBar.value = boulder.position.x;
        meterCounter.text = Mathf.Round(boulder.position.x).ToString() + "m";

        Vector3 newArrowpos = new (player.position.x, player.position.y + offsetY, 0);
        arrow.transform.position = newArrowpos;

        Vector3 offset = boulder.position - arrow.transform.position;
        arrow.transform.rotation = Quaternion.LookRotation(Vector3.forward, offset);

        if (boulder.position.x > cam.position.x + camSizeX ||
            boulder.position.x < cam.position.x - camSizeX ||
            boulder.position.y > cam.position.y + camSizeY ||
            boulder.position.y < cam.position.y - camSizeY
        ) {
            arrow.SetActive(true);
        } else {
            arrow.SetActive(false);
        }
    }
}
