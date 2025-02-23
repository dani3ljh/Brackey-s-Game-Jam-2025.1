using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// Handles Boulder Controllers
/// </summary>
public class BoulderController : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private float deltaX = 100;
    [SerializeField] private float deltaScale = 2;
    [SerializeField] private float startGravity = -5;
    [SerializeField] private float winX;
    [SerializeField] private string winSceneName;
    private float nextX;
    private float gravity;

    [Header("Game Objects")]
    [SerializeField] private Transform dust;
    [SerializeField] private SceneLoader sl;
    private Rigidbody2D rb;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods are called.
    /// </summary>
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        nextX = deltaX;
        gravity = startGravity;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate() {
        if (transform.position.x >= winX) {
            sl.LoadScene(winSceneName);
        }

        if (Mathf.Round(transform.position.x) == nextX)
        {
            nextX += deltaX;
            gravity -= deltaScale;
        }

        rb.AddForce(new(gravity, 0));
        dust.transform.position = transform.position;
    }
}
