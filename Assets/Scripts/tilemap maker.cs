using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class tilemapmaker : MonoBehaviour
{
    [Header("Data")]
    public float[] rot;
    public float rowAmount;
    public float collumAmount;
    private float offsetX = 0.1594f;
    private float offsetY = 0.1594f;
    private float x = -8.804f;
    private float y = -12.414f;

    [Header("Game Objects")]
    public GameObject tile1;
    public GameObject tile2;
    public GameObject tile3;
    public GameObject tile4;



    // Start is called before the first frame update
    void Start()
    {
        while (0 < collumAmount)
        {
            while (0 < rowAmount)
            {
                Vector3 spawnPos = new Vector3(x, y,0);
                Instantiate(tile1, spawnPos, Quaternion.identity);
                x += offsetX;
            }
            y += offsetY;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
