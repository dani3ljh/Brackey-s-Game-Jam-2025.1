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
    public float dif = 100;
    public float difAccel = 100;
    public float scaleIncre = 2;
    public float gravity = -5;
    [Header("Game Objects")]
    public GameObject dust;
    Rigidbody2D rb;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods are called.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        Vector2 dis = transform.position;
        if (math.round(dis.x) == dif)
        {
            dif += difAccel;
            gravity = gravity - scaleIncre;
        }
        Vector2 grav = new Vector2(gravity, 0);
        rb.AddForce(grav);
        dust.transform.position = transform.position;
    }
}
