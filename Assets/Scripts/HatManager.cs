using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// Manages Secret Hats
/// </summary>
public class HatManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private float initialY;
    [SerializeField] private float deltaY;
    private int hats = 0;

    /// <summary>
    /// Instantiates a hat on the player
    /// </summary>
    /// <param name="hat">Hat prefab</param>
    public void AddHat(GameObject hat) {
        GameObject newHat = Instantiate(hat, transform);
        
        newHat.transform.SetLocalPositionAndRotation(new Vector3(0, initialY + deltaY * hats, -0.01f * (hats + 1)), Quaternion.identity);

        hats++;
    }
}
