using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles Saving Volume to File
/// </summary>
public class VolumeManager : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private Slider slider;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods are called.
    /// </summary>
    private void Start() {
        if (PlayerPrefs.GetInt("SetVolume") == 0) {
            slider.value = 1;
            OnSliderChanged();
        } else {
            slider.value = PlayerPrefs.GetFloat("Volume");
        }
    }

    /// <summary>
    /// Handles Saving Volume
    /// </summary>
    public void OnSliderChanged() {
        print($"Set volume to {slider.value}");
        PlayerPrefs.SetFloat("Volume", slider.value);
        PlayerPrefs.SetInt("SetVolume", 1);
        PlayerPrefs.Save();
    }
}
