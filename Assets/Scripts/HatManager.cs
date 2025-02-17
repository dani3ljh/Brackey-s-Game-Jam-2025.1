using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.Video;

/// <summary>
///
/// </summary>
public class HatManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private float initialY;
    [SerializeField] private float deltaY;
    private int hats = 0;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods are called.
    /// </summary>
    private void Start() {
        
    }

    public void AddHat(GameObject hat) {
        GameObject newHat = Instantiate(hat, transform);
        
        newHat.transform.SetLocalPositionAndRotation(new Vector3(0, initialY + deltaY * hats, -0.01f * (hats + 1)), Quaternion.identity);

        hats++;
    }
}
